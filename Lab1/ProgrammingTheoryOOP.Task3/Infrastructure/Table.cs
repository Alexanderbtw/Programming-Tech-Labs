using System.Collections;
using System.Text;
using ProgrammingTheoryOOP.Task3.Entities;
using ProgrammingTheoryOOP.Task3.Exceptions;

namespace ProgrammingTheoryOOP.Task3.Infrastructure;

public class Table : IEnumerable<Entity> {
	private readonly Dictionary<Entity, int> _entities = new Dictionary<Entity, int>();
	private int[] _freeSpace;
	
	public Table(int height, int width) {
		Length = height;
		Width = width;
		_freeSpace = new int[MinEdge];
		Array.Fill(_freeSpace, MaxEdge);
	}
	
	public int Length { init; get; }
	public int Width { init; get; }
	public int MinEdge => Math.Min(Length, Width);
	public int MaxEdge => Math.Max(Length, Width);
	public int Area => Length * Width;
	public decimal TotalCost =>  _entities.Keys.Sum(e => e.Cost);

	public void Put(Entity entity) {
		if (entity.MinEdge > this.MinEdge || entity.MinSurface > this.Area) {
			throw new TooBigException($"The {typeof(Entity)} is too big");
		}

		int[] backupFreeSpace = (int[])_freeSpace.Clone();
		for (int i = 0; i < _freeSpace.Length; i++) {
			int fillAmount = entity.MinEdge;
			_freeSpace = backupFreeSpace;
			while (i < _freeSpace.Length && _freeSpace[i] >= entity.MinSurface / entity.MinEdge ) {
				_freeSpace[i++] -= entity.MinSurface / entity.MinEdge;
				if (--fillAmount == 0) {
					_entities.Add(entity, i - entity.MinEdge);
					return;
				}
			}
		}
		
		throw new TooBigException($"The {entity.Title} ({entity.GetType().Name}) is too big");
	}
	
	public void Take(Entity entity) {
		if (!_entities.TryGetValue(entity, out int startPos)) {
			throw new EntityNotFoundException($"{entity.GetType().Name} {entity.Title} not found");
		}
		for (int i = 0; i < entity.MinEdge; i++) {
			_freeSpace[startPos + i] += entity.MinSurface / entity.MinEdge;
		}
	}
	
    public bool TryTake(Entity entity) {
	    if (!_entities.TryGetValue(entity, out int startPos)) return false;
	    
	    for (int i = 0; i < entity.MinEdge; i++) {
		    _freeSpace[startPos + i] += entity.MinSurface / entity.MinEdge;
	    }
	    return true;
    }

    public Entity? Find(string title) {
		return _entities.Keys.FirstOrDefault(e => e.Title == title);
    }
    
    public Entity? Find(decimal cost) {
		return _entities.Keys.FirstOrDefault(e => e.Cost == cost);
    }

    public IEnumerator<Entity> GetEnumerator() {
	    return _entities.Keys.GetEnumerator();
    }

    public override string ToString() {
	    var sb = new StringBuilder();
	    sb.AppendLine($"Table: {Length}x{Width} (Area: {Area})\n Entities:");
	    foreach (var entity in _entities.Keys) {
		    sb.AppendLine(entity + "\n");
	    }
	    
	    return sb.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator() {
	    return GetEnumerator();
    }
}