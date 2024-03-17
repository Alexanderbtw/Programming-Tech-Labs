using System.Collections;
using System.Text;
using ProgrammingTheoryOOP.Task7.Exceptions;

namespace ProgrammingTheoryOOP.Task7.Entities;

public class Group : IEnumerable<Student> {
	public string Title { get; set; }
	private readonly Student?[] _students;
	public int MinCount { init; get; }
	public int MaxCount { init; get; }
	
	private int _index = 0;
	public int Count => _index + 1;
	
	public Group(int minCount, int maxCount, string title) {
		Title = title;
		_students = new Student?[maxCount];
		MinCount = minCount;
		MaxCount = maxCount;
	}
	
	public Group((int, int) range, string title) {
		Title = title;
		_students = new Student[range.Item2];
		MinCount = range.Item1;
		MaxCount = range.Item2;
	}

	public void TryAddStudent(Student student) {
		if (Count == MaxCount) return;
		
		_students[_index] = student;
		_index++;
	}
	
	public void AddStudent(Student student) {
		// Throw out of range exception if count students > max
		_students[_index] = student;
		_index++;
	}
	
	public void RemoveStudent(Student student) {
		if (Count == MinCount) {
			throw new TooFewException("Too few students in group");
		}
		
		_students[_index] = null;
		_index--;
	}
	
	public Student? Find(string name, string surname) {
		return _students
		   .TakeWhile(student => student != null)
		   .FirstOrDefault(student => student!.Name == name && student!.Surname == surname);
	}

	public IEnumerator<Student> GetEnumerator() {
		foreach (var student in _students) {
			if (student == null) break;
			yield return student;
		}
	}

	public override string ToString() {
		var sb = new StringBuilder();
		sb.Append($"{Title} ({Count})");
		foreach (var student in _students) {
			if (student != null) {
				sb.Append($"\n{student}");
			}
		}
		return sb.ToString();
	}

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}

	public Student? this[int index] => _students[index];
}