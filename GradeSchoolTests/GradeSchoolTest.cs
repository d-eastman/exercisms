﻿using System.Collections.Generic;
using NUnit.Framework;
using GradeSchoolLibrary;

[TestFixture]
public class GradeSchoolTest
{
    private School school;

    [SetUp]
    public void Setup()
    {
        school = new School();
    }

    [Test]
    public void New_school_has_an_empty_roster()
    {
        Assert.That(school.Roster, Has.Count.EqualTo(0));
    }

    [Test]
    public void Adding_a_student_adds_them_to_the_roster_for_the_given_grade()
    {
        school.Add("Aimee", 2);
        var expected = new List<string> { "Aimee" };
        Assert.That(school.Roster[2], Is.EqualTo(expected));
    }

    [Test]
    public void Adding_more_students_to_the_same_grade_adds_them_to_the_roster()
    {
        school.Add("Blair", 2);
        school.Add("James", 2);
        school.Add("Paul", 2);
        var expected = new List<string> { "Blair", "James", "Paul" };
        Assert.That(school.Roster[2], Is.EqualTo(expected));
    }

    [Test]
    public void Adding_students_to_different_grades_adds_them_to_the_roster()
    {
        school.Add("Chelsea", 3);
        school.Add("Logan", 7);
        Assert.That(school.Roster[3], Is.EqualTo(new List<string> { "Chelsea" }));
        Assert.That(school.Roster[7], Is.EqualTo(new List<string> { "Logan" }));
    }

    [Test]
    public void Grade_returns_the_students_in_that_grade_in_alphabetical_order()
    {
        school.Add("Franklin", 5);
        school.Add("Bradley", 5);
        school.Add("Jeff", 1);
        var expected = new List<string> { "Bradley", "Franklin" };
        Assert.That(school.Grade(5), Is.EqualTo(expected));
    }

    [Test]
    public void Grade_returns_an_empty_list_if_there_are_no_students_in_that_grade()
    {
        Assert.That(school.Grade(1), Is.EqualTo(new List<string>()));
    }

    [Test]
    public void Student_names_in_each_grade_in_roster_are_sorted()
    {
        school.Add("Jennifer", 4);
        school.Add("Kareem", 6);
        school.Add("Christopher", 4);
        school.Add("Kyle", 3);
        Assert.That(school.Roster[3], Is.EqualTo(new List<string> { "Kyle" }));
        Assert.That(school.Roster[4], Is.EqualTo(new List<string> { "Christopher", "Jennifer" }));
        Assert.That(school.Roster[6], Is.EqualTo(new List<string> { "Kareem" }));
    }

    [Test]
    public void Duplicate_Student_Names_Are_Allowed_And_Sorted_Properly()
    {
        school.Add("Blair", 2);
        school.Add("James", 2);
        school.Add("Blair", 2);
        var expected = new List<string> { "Blair", "Blair", "James" };
        Assert.That(school.Roster[2], Is.EqualTo(expected));
    }

    [Test]
    public void Mutate_List_Add_Name_Manually()
    {
        school.Add("Jennifer", 3);
        school.Roster[3].Add("James"); //This doesn't modify the internal data, only the copy
        Assert.That(school.Grade(3), Is.EqualTo(new List<string> { "Jennifer" }));
    }
    
    [Test]
    public void Mutate_List_Change_Name_Manually_Thru_Roster()
    {
        school.Add("Jennifer", 3);
        school.Roster[3][0] = "Jane"; //This doesn't modify the internal data, only the copy
        Assert.That(school.Grade(3), Is.EqualTo(new List<string> { "Jennifer" }));
    }

    [Test]
    public void Mutate_List_Change_Name_Manually_Thru_Grade()
    {
        school.Add("Jennifer", 3);
        school.Grade(3)[0] = "Jane"; //This doesn't modify the internal data, only the copy
        Assert.That(school.Grade(3), Is.EqualTo(new List<string> { "Jennifer" }));
    }

    [Test]
    public void Mutate_List_Repoint_Roster_Array()
    {
        school.Add("Jennifer", 3);
        school.Add("James", 4);
        school.Roster[3] = school.Roster[4]; //This doesn't modify the internal data, only the copy
        Assert.That(school.Grade(3), Is.EqualTo(new List<string> { "Jennifer" }));
        Assert.That(school.Grade(4), Is.EqualTo(new List<string> { "James" }));
    }
}