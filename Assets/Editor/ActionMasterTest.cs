using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest
{
    private List<int> pinFalls;

    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]
    public void PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01_StrikeOnFirstThrowEndsTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02_Bowl8ReturnTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03_Bowl28ReturnsEndTurn()
    {
        pinFalls.Add(2);
        pinFalls.Add(8);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T04_CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05_CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T06_YouTubeRollEndInEndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07_GameEndsAtBowl20()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08_ChallengeTest1()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T09_ChallengeTest2()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T10_ChallengeTest3_2LastStrikes()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T11_ChallengeTest4_2ndBowl10()
    {
        int[] rolls = { 0, 10, 5, 1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T12_ChallengeTest5_3LastStrikes()
    {
        int[] rollsArr = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        List<int> rolls = rollsArr.ToList();
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls));

        rolls.Add(10);
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls));

        rolls.Add(10);
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls));
    }

    [Test]
    public void T13()
    {
        int[] rolls = { 0, 1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
}