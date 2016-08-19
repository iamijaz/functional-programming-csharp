using System;
using System.Linq;
using System.Text;

namespace FunctionalCSharp.Sample3.After
{
    class Program
    {
        public static Func<int, int> Add(int x) => y => x + y;
    
        static void Main(string[] args)
        {

            // curried Method application 
            var r = new[] { 2, 4, 6, 8 }
        .Select(Add(5))
        .Select(x => x.ToString())
        .Aggregate((x, y) => x + Environment.NewLine + y)
        .Tee(Console.WriteLine);

            // Transformation Pipeline
            Disposable
                .Using(
                    StreamFactory.GetStream,
                    stream => new byte[stream.Length].Tee(b => stream.Read(b, 0, (int)stream.Length)))
                .Map(Encoding.UTF8.GetString)
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select((s, ix) => Tuple.Create(ix, s))
                .ToDictionary(k => k.Item1, v => v.Item2)
                .Map(HtmlBuilder.BuildSelectBox("theDoctors", true))
                .Tee(Console.WriteLine);

            // String Validation Pipeline
            "Doctor Who"
                .Map(Validator.IsNotNull)
                .Bind(Validator.IsNotEmpty)
                .Bind(Validator.MinLength(8))
                .Map(result => result.IsSuccess ? result.SuccessValue : result.FailureValue)
                .Tee(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
