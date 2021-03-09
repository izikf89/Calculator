using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AteraMission.Models.Calculator
{
    public class ParserExperssion
    {
        public static double Parser(string ex)
        {
            double bulk;

            ex = FixExpression(ex);
            CheckInputIsValid(ex);

            List<Expression> exps = ConvertStringToExpressionList(ex);

            CalculatePriorities(exps);

            bulk = CalculateAll(exps);

            return bulk;
        }

        private static void CheckInputIsValid(string ex)
        {
            Regex rgx = new Regex(@"^[0-9.*-/+]+$");
            if (!rgx.IsMatch(ex))
                throw new InvalidInputException();
        }


        private static double CalculateAll(List<Expression> exps)
        {
            double bulk = ((Number)exps[0]).value;
            for (int i = 1; i < exps.Count; i++)
            {
                Expression exp = exps[i];
                if (exp is Number)
                    continue;

                bulk = ((Operator)exp).Calculate(bulk, ((Number)exps[i + 1]).value);
                i++;
            }

            return bulk;
        }
        private static void CalculatePriorities(List<Expression> exps)
        {
            for (int i = 0; i < exps.Count; i++)
            {
                Expression exp = exps[i];
                if (exp is Number)
                    continue;

                if (exp is Div || exp is Multi)
                {
                    double res = ((Operator)exp).Calculate(((Number)exps[i - 1]).value, ((Number)exps[i + 1]).value);
                    ((Number)exps[i - 1]).value = res;
                    exps.RemoveAt(i);
                    exps.RemoveAt(i);
                    i--;
                }
            }
        }

        private static List<Expression> ConvertStringToExpressionList(string ex)
        {
            StringBuilder sb = new StringBuilder();
            Queue<Expression> q = new Queue<Expression>();

            foreach (char c in ex.ToCharArray())
            {
                if (char.IsDigit(c) || c == '.')
                    sb.Append(c);
                else
                {
                    if (sb.Length == 0) // multi operator or ex start or end with operator
                        throw new InvalidInputException();

                    q.Enqueue(new Number(double.Parse(sb.ToString())));
                    sb.Clear();

                    q.Enqueue(GetOperator(c));
                }
            }

            q.Enqueue(new Number(double.Parse(sb.ToString())));

            List<Expression> exps = q.ToList();
            return exps;
        }

        private static string FixExpression(string ex)
        {
            ex = Regex.Replace(ex, @"\s+", ""); // trim all white space

            if (ex[0] == '-')
                ex = "0" + ex;

            return ex;
        }

        private static Operator GetOperator(char c)
        {
            Operator op = null;

            switch (c)
            {
                case '+':
                    op = new Plus();
                    break;
                case '-':
                    op = new Minus();
                    break;
                case '*':
                    op = new Multi();
                    break;
                case '/':
                    op = new Div();
                    break;
            }

            return op;
        }
    }
}
