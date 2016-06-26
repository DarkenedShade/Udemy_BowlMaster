using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {

    //Code used from udemy course
    public enum Action { Tidy, Reset, EndTurn, EndGame, Undefined };

    public static Action NextAction(List<int> rolledPins)
    {
        Action nextAction = Action.Undefined;
        List<int> rolls = new List<int>(rolledPins);

        for (int i = 0; i < rolls.Count; i++)
        { // Step through rolls

            if (i == 20)
            {
                nextAction = Action.EndGame;
            }
            else if (i >= 18 && rolls[i] == 10)
            { // Handle last-frame special cases
                nextAction = Action.Reset;
            }
            else if (i == 19)
            {
                if (rolls[18] == 10 && rolls[19] == 0)
                {
                    nextAction = Action.Tidy;
                }
                else if (rolls[18] + rolls[19] == 10)
                {
                    nextAction = Action.Reset;
                }
                else if (rolls[18] + rolls[19] >= 10)
                {  // Roll 21 awarded
                    nextAction = Action.Tidy;
                }
                else
                {
                    nextAction = Action.EndGame;
                }
            }
            else if (i % 2 == 0)
            { // First bowl of frame
                if (rolls[i] == 10)
                {
                    rolls.Insert(i, 0); // Insert virtual 0 after strike
                    nextAction = Action.EndTurn;
                }
                else
                {
                    nextAction = Action.Tidy;
                }
            }
            else
            { // Second bowl of frame
                nextAction = Action.EndTurn;
            }
        }

        return nextAction;
    }

    /*  
     *  My Old Code
     *  
        public enum Action
        {
            Reset,
            Tidy,
            EndTurn,
            EndGame
        }

        private int bowl = 1;
        private int[] rolls = new int[21];

        public static Action NextAction(List<int> pinFalls)
        {
            Action lastAction = new Action();
            ActionMaster currentInstance = new ActionMaster();
            foreach (int pinsDropped in pinFalls)
            {
                lastAction = currentInstance.Bowl(pinsDropped);
            }
            return lastAction;
        }

        private Action Bowl(int pinsDropped)
        {
            if(pinsDropped < 0 || pinsDropped > 10) { throw new UnityException("Dropped Pin Count Out of range");}

            rolls[bowl - 1] = pinsDropped;

            if(bowl == 21) { return Action.EndGame; }

            #region Special Cases
            if (rolls[19-1] == 10 && pinsDropped < 10)
            {
                bowl++;
                return Action.Tidy;
            }
            else if(bowl >= 19 && Bowl21Awarded())
            {
                bowl++;
                return Action.Reset;
            }
            else if (bowl == 20 && !Bowl21Awarded())
            {
                return Action.EndGame;
            }
            #endregion

            if (pinsDropped == 10)
            {
                bowl += (bowl % 2 == 0?1:2);
                return Action.EndTurn;
            }
            if (bowl % 2 != 0)
            {
                bowl++;
                return Action.Tidy;
            }
            else if(bowl % 2 == 0)
            {
                bowl++;
                return Action.EndTurn;
            }
            throw new UnityException("Not sure what action to return");
        }

        private bool Bowl21Awarded()
        {
            return ((rolls[19 - 1] + rolls[20 - 1]) >= 10);
        }
        */
}
