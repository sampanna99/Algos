using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithsPractise.LeetCode_Eric.Phase6
{
    public class StacksAndQueues
    {
    }

    public class StackUsingQueue
    {

    }

    public class ValidParenthesis
    {

        public string Brackets { get; set; }

        public Dictionary<string, string> DictionaryForClose { get; set; }

        public ValidParenthesis()
        {
            DictionaryForClose = new Dictionary<string, string>();
        }

        public void Algorithmn()
        {
            //Add it to the dictionary ex: } corresponds to { and rest
            //loop through Brackets char if open add the closing to stack; if closed pop and if no match break

            var stack = new Stack<string>();
            var isValid = true;
            foreach (var bracket in Brackets)
            {
                var bracketAsStr = bracket.ToString();
                if (DictionaryForClose.ContainsKey(bracketAsStr))
                {
                    //means is closing bracket
                    var equivalentFromDictOpen = DictionaryForClose[bracketAsStr];
                    var pop = stack.Pop();
                    if (pop != equivalentFromDictOpen)
                    {
                        isValid = false;
                        break;
                    }
                    continue;
                }
                stack.Push(bracketAsStr);
            }

            Console.WriteLine($"this Brackets string is {isValid}");
        }
    }

    public class MinStack
    {
        public string[] GivenOperations { get; set; }

        public string[][] ArrayOfArray { get; set; }

        public MinStack()
        {
            
        }
        public void Algorithmn()
        {
            var stack = new Stack<int>();
            var stackMin = new Stack<int>();
            var currentMin = Int32.MaxValue;
            var listOfAns = new List<int?>();
            for (int i = 0; i < GivenOperations.Length; i++)
            {
                var value = GivenOperations[i];
                switch (value)
                {
                    case "push":
                        var valueOnAnoither = Convert.ToInt32(ArrayOfArray[i][0]);
                        stack.Push(valueOnAnoither);
                        if (currentMin > valueOnAnoither)
                        {
                            currentMin = valueOnAnoither;
                            
                        }
                        stackMin.Push(currentMin);
                        listOfAns.Add(null);
                        break;
                    case "getMin":
                        //just get the min
                        listOfAns.Add(currentMin);
                        break;
                    case "pop":
                        var poppedVal = stack.Pop();
                        stackMin.Pop();
                        var peekVal = stackMin.Peek();
                        currentMin = peekVal;
                        listOfAns.Add(poppedVal);
                        break;
                    case "top":
                        var peekValHere = stack.Peek();
                        listOfAns.Add(peekValHere);
                        break;
                }
            }
        }


    }

    public class NextGreaterElement
    {
        public int[] GivenArraySmall { get; set; }
        public int[] GivenArrayBigArray { get; set; }
        public NextGreaterElement()
        {
            
        }

        public void Algorithmn()
        {
            //go through each on num2
            //if 0 add it to the stack
            //go the other and peek from the stack and if it greater keep popping and until it's empty
            //when it's empty add that number
            //when finishes take everything out of the stack and it's -1 for all

            var stack = new Stack<int>();
            //for (int i = 0; i < GivenArrayBigArray.Length; i++)
            //{
            //    var valueHere = GivenArrayBigArray[i];
            //    var peekVal = stack.Peek();
            //    var actualValueOnInd = GivenArrayBigArray[peekVal];   
            //    if (stack.Count == 0 || actualValueOnInd < valueHere)
            //    {
            //        stack.Push(i); 
            //    }
            //    else
            //    {
            //        var popIt = peekVal;
            //        var valAtPop = actualValueOnInd;
            //        //var popIt = stack.Pop();
            //        //var valAtPop = GivenArrayBigArray[popIt];

            //        while (valAtPop < valueHere)
            //        {
            //            stack.Pop();
            //            outPut1[popIt] = valueHere;
            //            //popIt = stack.Pop();
            //            //valAtPop = GivenArrayBigArray[popIt];
            //            if (stack.Count > 0)
            //            {
            //                popIt = stack.Peek();
            //                valAtPop = GivenArrayBigArray[popIt];
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }

            //    }
            //}

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < GivenArraySmall.Length; i++)
            {
                dict.Add(GivenArraySmall[i], i);
            }

            for (int i = 0; i < GivenArrayBigArray.Length; i++)
            {
                var valueHere = GivenArrayBigArray[i];
                
                if (stack.Count == 0)
                {
                    if (dict.ContainsKey(valueHere))
                    {
                        stack.Push(valueHere);
                    }
                }
                else
                {
                    var peekVal = stack.Peek();
                    if (peekVal > valueHere)
                    {
                        // means this is the next big

                        while (peekVal > valueHere)
                        {
                            var popped = stack.Pop();
                            var indexAt = dict[popped];
                            GivenArraySmall[indexAt] = popped;
                            if (stack.Count > 0)
                            {
                                peekVal = stack.Peek();
                            }
                        }
                    }

                    if (dict.ContainsKey(valueHere))
                    {
                        stack.Push(valueHere);
                    }
                }
            }

            //now empty the stack
            //var valueHere = 
            while (stack.Count != 0)
            {
                var popped = stack.Pop();
                var index = dict[popped];
                GivenArraySmall[index] = -1;
            }
        }
    }

    public class DailyTemperatures
    {
        public int[] GivenDailyTemperatures { get; set; }

        public void ALgorithmn()
        {
            //add number index if 0 and after popping anything smaller


            var stack = new Stack<int>();

            for (int i = 0; i < GivenDailyTemperatures.Length; i++)
            {
                var valueHere = GivenDailyTemperatures[i];

                if (stack.Count != 0)
                {
                    var peekedIndex = stack.Peek();
                    var peekedValue = GivenDailyTemperatures[peekedIndex];

                    if (valueHere > peekedValue)
                    {

                        while (peekedValue < valueHere)
                        {
                            stack.Pop();
                            GivenDailyTemperatures[peekedIndex] = i - peekedIndex;
                            if (stack.Count == 0)
                            {
                                break;
                            }

                            peekedIndex = stack.Peek();
                            peekedValue = GivenDailyTemperatures[peekedIndex];
                        }

                    }
                    else
                    {
                        stack.Push(i);
                    }
                }
                else
                {
                    stack.Push(i);
                }
            }

            while (stack.Count > 0)
            {
                var popit = stack.Pop();
                GivenDailyTemperatures[popit] = 0;
            }
        }
    }

    public class BasicCalculator
    {
        public string ExpressionGiven { get; set; }

        //It works but Let's try dfs way
        public void Algorithmn()
        {
            //create two operation number operation number
            //num operator num

            var stack = new Stack<string>();

            foreach (var eachChar in ExpressionGiven)
            {
                stack.Push(eachChar.ToString());
            }

            int? firstNumber = null; 
            int? secondNUmber = null;
            var middleOperator = "";
            //var (firstNumber, secondNUmber, middleOperator) = (0, 0, "");

            var isCompleteNumber = false;
            var currentlymaking = "";
            var currentMakingOperand = "";
            while (stack.Count > 0)
            {
                var poppedOne = stack.Pop();

                var integerToBemade = 0;
                var isNumber = Int32.TryParse(poppedOne, out integerToBemade);
                if (isNumber)
                {
                    currentlymaking = integerToBemade + currentlymaking;
                }
                //Only check for "("
                else if (poppedOne != ")")
                {
                    //means operand
                    if (secondNUmber == null)
                    {
                        secondNUmber = Int32.Parse(currentlymaking);
                    }
                    else if(firstNumber == null)
                    {
                        firstNumber = Int32.Parse(currentlymaking);
                    }
                    else
                    {
                        //that means it put in second operand and first
                        //do the operation
                        secondNUmber = DoTheOperation((int)firstNumber, (int)secondNUmber, middleOperator);
                        firstNumber = null;
                        middleOperator = "";
                    }


                    if (currentMakingOperand == "")
                    {
                        middleOperator = poppedOne;
                    }
                    else
                    {
                        if (poppedOne == "-" && currentMakingOperand == "-")
                        {
                            middleOperator = "+";
                        }
                        else if(poppedOne == "-" || currentMakingOperand == "-")
                        {
                            middleOperator = "-";
                        }
                        else
                        {
                            middleOperator = "+";
                        }
                    }

                }
                else
                {
                    if (firstNumber != null)
                    //if (firstNumber != null && secondNUmber != null) //no need to check second
                    {
                        // do the operation here
                        secondNUmber = DoTheOperation((int)firstNumber, (int)secondNUmber, middleOperator);
                        firstNumber = null;
                        middleOperator = "";
                    }
                    else
                    {
                        //find the number in between them
                        if (secondNUmber != null)
                        {
                            //find the first number from ) --> (

                            // do the logic here again.

                        }
                        else
                        {
                            //find the first number from ) --> (

                        }

                        //This will never be there or else the whole thing would be even more difficult
                        if (secondNUmber != null && middleOperator == "")
                        {
                            middleOperator = "*";
                        }
                        
                    }
                }

            }

        }

        public int? FirstNum { get; set; }
        public int? SecondNum { get; set; }
        public string Operator { get; set; }

        private int FindEndBracketIndex(int startIndex)
        {
            var lastOne = ExpressionGiven.Length;
            var smallerFOund = 0;
            var returnIndex = 0;
            while (startIndex < lastOne)
            {
                var valueOnThisIndex = ExpressionGiven[startIndex].ToString();

                if (valueOnThisIndex == "(")
                {
                    smallerFOund += 1;
                }

                if (valueOnThisIndex == ")")
                {
                    if (smallerFOund == 0)
                    {
                        returnIndex = startIndex;
                        break;
                    }
                    else
                    {
                        smallerFOund -= 1;
                    }
                }

                startIndex += 1;
            }

            return returnIndex;
        }

        //https://www.youtube.com/watch?v=Q193Tqb7_9A&list=PL1MJrDFRFiKZxTl1a1lnhxJ51FoLFdEIF&index=7
        public int DFSWayAlgo(int index)
        {
            //base case
            if (index >= ExpressionGiven.Length)
            {
                if (FirstNum != null && SecondNum != null && Operator != "")
                {
                    return DoTheOperation((int)FirstNum, (int)SecondNum, Operator);
                }
                else
                {
                    return -1;
                }
            }

            var valueHere = ExpressionGiven[index].ToString();

            if (valueHere == ")")
            {
                if (FirstNum != null && SecondNum != null && Operator != "")
                {
                    return DoTheOperation((int)FirstNum, (int)SecondNum, Operator);
                }
                else
                {
                    return -1;
                }
            }

            var integetCreated = Int32.TryParse(valueHere.ToString(), out int number);

            if (FirstNum != null && SecondNum != null && Operator != "")
            {
                if (integetCreated)
                {
                    SecondNum = Convert.ToInt32(SecondNum.ToString() + valueHere);
                    return DFSWayAlgo(index + 1);
                }
                else
                {
                    //do the operation
                    //firstNumber To That Number
                    FirstNum = DoTheOperation((int)FirstNum, (int)SecondNum, Operator);
                    return DFSWayAlgo(index + 1);
                }
            }
            else
            {
                if (integetCreated)
                {
                    //where do we put it first or second
                    if (Operator == "")
                    {
                        FirstNum = FirstNum != null
                            ? Convert.ToInt32(FirstNum + valueHere)
                            : Convert.ToInt32(valueHere);
                    }
                    else
                    {
                        SecondNum = SecondNum != null
                            ? Convert.ToInt32(SecondNum + valueHere)
                            : Convert.ToInt32(valueHere);
                    }
                    return DFSWayAlgo(index + 1);
                }
                else
                {
                    //means operator or bracket
                    if (valueHere == "(")
                    {
                        //need to create a variable repo for all and pass new instance
                        var prevValues = (FirstNum, SecondNum, Operator);

                        FirstNum = null;
                        SecondNum = null;
                        Operator = "";
                        var answerFromHere = DFSWayAlgo(index + 1);
                        if (prevValues.FirstNum == null)
                        {
                            FirstNum = answerFromHere;
                        }
                        else
                        {
                            SecondNum = answerFromHere;
                        }

                        var findTheIndexofEndBracket = FindEndBracketIndex(index + 1);
                        return DFSWayAlgo(findTheIndexofEndBracket + 1);
                    }
                    else
                    {
                        Operator = valueHere;
                        return DFSWayAlgo(index + 1);
                    }
                }
            }

            //should never come here
        }

        private int DoTheOperation(int firstNum, int SecondNum, string operand)
        {
            var returnThis = 0;
            switch (operand)
            {
                case "+":
                    returnThis = firstNum + SecondNum;
                    break;
                case "-":
                    returnThis = firstNum - SecondNum;
                    break;
                //THis wouldn't be tehre
                case "*":
                    break;
               
            }

            return returnThis;
        }

    }

    public class BasicCalculator2
    {
        public string ExpressionGiven { get; set; }

        private (int, int) FindNextNum(int index)
        {
            var numberMade = "";
            var indexRet = 0;
            while (index < ExpressionGiven.Length)
            {
                var valu = ExpressionGiven[index].ToString();

                var isNum = Int32.TryParse(valu, out int realval);
                if (isNum)
                {
                    numberMade += realval;
                }
                else
                {
                    indexRet = index;
                    break;
                }
            }

            var second = indexRet == 0 ? ExpressionGiven.Length : indexRet;
            var returnNum = Convert.ToInt32(numberMade);
            return (returnNum, second);
        }
        public BasicCalculator2()
        {
            
            //go through each and add it to 2 stack 1st numbers and 2nd operators. Flatten /s 

            var iteration = 0;
            int? numberMaking = null;
            bool nextnumberMultiplyByNegOne = false;
            var stack = new Stack<int>();
            while (iteration < ExpressionGiven.Length)
            {
                var stringMade = ExpressionGiven[iteration].ToString();
                var numberMade = Int32.TryParse(stringMade, out int integerValue);
                if (numberMade)
                {

                    numberMaking = numberMaking == null ? integerValue : 
                        Convert.ToInt32(numberMaking + stringMade);
                }
                else
                {
                    if (stringMade == "*" || stringMade == "/")
                    {
                        //find next number
                        var nextNum = FindNextNum(iteration + 1);
                        var changedNum = 0;
                        switch (stringMade)
                        {
                            case "*":
                                changedNum = stack.Pop() * nextNum.Item1;
                                break;
                            case "/":
                                 changedNum = stack.Pop() / nextNum.Item1;
                                break;
                        }
                        stack.Push(changedNum);
                        iteration = nextNum.Item2;
                        continue;
                    }
                    else
                    {
                        if (nextnumberMultiplyByNegOne)
                        {
                            stack.Push(-integerValue);
                        }
                        else
                        {
                            stack.Push(integerValue);
                        }

                        nextnumberMultiplyByNegOne = stringMade == "-";
                    }
                }

                iteration += 1;
            }


            var sum = 0;
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Answer is {sum}");

        }
        public void Algorithmn()
        {

        }
    }

    public class BasicCalculator3
    {

        public string GivenExpression { get; set; }

        public void Algorithmn()
        {
            //Create Calculate that calculate the sum takes start index and end index.
            //whenever ( it calles it again
        }
        public (int, int) Calculate(int startInd, bool isBracket)
        {
            //+ or - add it to stack
            //* or / find next num

            var i = startInd;
            var currentlyMaking = "";
            var isMinusBefore = false;
            var currentMiniInside = 0;
            var stack = new Stack<int>();
            var firstValToR = 0;
            var secondValToRet = 0;


            while (i < GivenExpression.Length)
            {
                var valueHere = GivenExpression[i].ToString();
                var isNum = Int32.TryParse(valueHere, out int integerValue);
                if (isNum)
                {
                    currentlyMaking += integerValue.ToString();
                }
                else
                {
                    //check if it is opening bracket
                    var integerMade = Int32.Parse(currentlyMaking);
                    if (valueHere == "(")
                    {
                        //find between two ()
                        var findAnsInBetweenBrack = Calculate(i + 1, true);
                        currentlyMaking = findAnsInBetweenBrack.Item1.ToString();
                        i = findAnsInBetweenBrack.Item2 + 1;
                        continue;
                    }
                    else if(valueHere == ")")
                    {
                        secondValToRet = i;
                         break;
                    }else if (valueHere == "*" || valueHere == "/")
                    {
                        //find the next Value
                        var nextVal = FindNextVal(i + 1);
                        var toputinStack = nextVal.Item1 * stack.Pop();
                        stack.Push(toputinStack);
                        i = nextVal.Item2 + 1;
                        continue;
                    }
                    else
                    {
                        if (isMinusBefore)
                        {
                            stack.Push(-integerMade);
                        }
                        else
                        {
                            stack.Push(integerMade);
                        }

                        isMinusBefore = valueHere == "-";
                    }

                    i += 1;
                }
            }

            var sum = 0;
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            return (sum, secondValToRet);
        }

        private (int, int) FindNextVal(int startIndex)
        {
            var i = startIndex;
            var currentlyMaking = "";

            var firstValTOR = 0;
            var secondValTOR = 0;


            while (i < GivenExpression.Length)
            {
                var valueHere = GivenExpression[i].ToString();
                var isNum = Int32.TryParse(valueHere, out int integerValue);

                if (isNum)
                {
                    currentlyMaking += integerValue.ToString();
                }
                else if(valueHere == "(")
                {
                    var valueRHere = Calculate(i + 1, true);
                    firstValTOR = valueRHere.Item1;
                    secondValTOR = valueRHere.Item2;
                    break;
                }
                else
                {
                    firstValTOR = Int32.Parse(currentlyMaking);
                    secondValTOR = i;
                    break;
                }

                i += 1;
            }

            return (firstValTOR, secondValTOR);
            //gives me ) indexValue

        }
    
    }

    public class NextGreaterElement2
    {


        public int[] GivenArray { get; set; }

        public NextGreaterElement2()
        {
            
        }

        public void Algorithmn()
        {
            var i = 0;
            var answerArray = new int[GivenArray.Length];
            var stack = new Stack<int>();

            while (i < GivenArray.Length)
            {
                var valueHere = GivenArray[i];
                if (stack.Count == 0)
                {
                    stack.Push(i);
                }
                else
                {
                    var peek = stack.Peek();
                    var valueAtPeeked = GivenArray[peek];

                    while (valueAtPeeked < valueHere && stack.Count > 0)
                    {
                        answerArray[peek] = valueHere;
                        stack.Pop();
                        if (stack.Count > 0)
                        {
                            peek = stack.Peek();
                            valueAtPeeked = GivenArray[peek];
                        } 
                    }
                }

                i += 1;
            }

            var j = 0;
            while (j < GivenArray.Length && stack.Count > 0)
            {
                var Val = GivenArray[j];
                var peekVal = stack.Peek();
                var actualValue = GivenArray[peekVal];

                while (actualValue < Val)
                {
                    answerArray[peekVal] = Val;
                    stack.Pop();
                    if (stack.Count > 0)
                    {
                        peekVal = stack.Peek();
                        actualValue = GivenArray[peekVal];
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
