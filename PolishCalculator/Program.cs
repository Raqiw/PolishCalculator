namespace PolishCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<double>();
            string arg;
            Console.WriteLine("Enter data one by one using the enter key: (calc - for calculated)");
            Console.WriteLine("For example: 7_5_*_3_9_+_/_calc");

            while ((arg = Console.ReadLine().ToLower()) != "exit")
            {
                double num;
                bool isNum = double.TryParse(arg, out num);

                if (isNum)
                {
                    stack.Push(num);
                }
                else
                {
                    double op2;
                    switch (arg)
                    {
                        case "+":
                            stack.Push(stack.Pop() + stack.Pop());
                            break;

                        case "*":
                            stack.Push(stack.Pop() * stack.Pop());
                            break;

                        case "-":
                            op2 = stack.Pop();
                            stack.Push(stack.Pop() - op2);
                            break;

                        case "/":
                            op2 = stack.Pop();
                            if (op2 != 0.0)
                            {

                                stack.Push(stack.Pop() / op2);
                            }
                            else
                            {
                                Console.WriteLine("Error. Can't divide by zero!");
                            }
                            break;

                        case "calc":
                            if (stack.Count == 1)
                            {
                            Console.WriteLine($"Result: {stack.Pop()}");
                            }
                            else
                            {
                                Console.WriteLine("Looks like you forgot to do the operation.");
                            }
                            break;

                        default:
                            Console.WriteLine("Error. Invalid arithmetic operator!");
                            break;
                    }
                }
            }
        }
    }
}