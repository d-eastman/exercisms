using System;
using NUnit.Framework;
using HL = Hamming.Library;

[TestFixture]
public class HammingTest
{
    [Test]
    public void No_difference_between_empty_strands()
    {
        Assert.That(HL.Hamming.Compute("", ""), Is.EqualTo(0));
    }

    [Test]
    public void No_difference_between_identical_strands()
    {
        Assert.That(HL.Hamming.Compute("GGACTGA", "GGACTGA"), Is.EqualTo(0));
    }

    [Test]
    public void Complete_hamming_distance_in_small_strand()
    {
        Assert.That(HL.Hamming.Compute("ACT", "GGA"), Is.EqualTo(3));
    }

    [Test]
    public void Hamming_distance_is_off_by_one_strand()
    {
        Assert.That(HL.Hamming.Compute("GGACGGATTCTG", "AGGACGGATTCT"), Is.EqualTo(9));
    }

    [Test]
    public void Smalling_hamming_distance_in_middle_somewhere()
    {
        Assert.That(HL.Hamming.Compute("GGACG", "GGTCG"), Is.EqualTo(1));
    }

    [Test]
    public void Larger_distance()
    {
        Assert.That(HL.Hamming.Compute("ACCAGGG", "ACTATGG"), Is.EqualTo(2));
    }

    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void Unequal_sized_strands()
    {
        HL.Hamming.Compute("AA", "A");
    }
}