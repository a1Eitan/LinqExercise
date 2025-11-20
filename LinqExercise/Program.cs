using LinqExercise.Data;
using LinqExercise.Extentions;
using LinqExercise.Models;
using System.Linq;
namespace LinqExercise
{
    public class Program
    {
        public static List<int> FilterList(List<int> lst, Func<int, bool> condition)
        {
            List<int> result = new List<int>();
            foreach (var item in lst)
            {
                if (condition(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {

            Func<int, bool> IsEven = (x) => x % 2 == 0;
            Console.WriteLine(IsEven(5));
            Console.WriteLine(IsEven(4));
            //---------------------------------
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> evens = FilterList(numbers, IsEven);
            List<int> fiveOrMore = FilterList(numbers, x => x >= 5);

            #region שימוש בFUNC במקום פונקציה רגילה
            Func<List<int>, Predicate<int>, List<int>> FilterFunc = (lst, condition) =>
            {
                {
                    List<int> result = new List<int>();
                    foreach (var item in lst)
                    {
                        if (condition(item))
                        {
                            result.Add(item);
                        }
                    }
                    return result;
                }
            };
            #endregion
            evens = FilterFunc(numbers, x => x % 2 == 0);
            #region שימוש בEXTENSIONS
            //example of using extension methods
            int a = 8;
            a.TalIsTheBest();

            numbers.YudAlef();
            int[] arr = new int[5];
            arr.YudAlef();



            #endregion

            #region שימוש בLINQ
            List<Student> students = new List<Student>()
            {
                new Student() { Name = "Alice", Age = 20, grade = 90, ClassName = "Math" },
                new Student() { Name = "Bob", Age = 22, grade = 85, ClassName = "Science" },
                new Student() { Name = "Charlie", Age = 21, grade = 95, ClassName = "Math" },
                new Student() { Name = "David", Age = 23, grade = 80, ClassName = "History" },
                new Student() { Name = "Eve", Age = 20, grade = 88, ClassName = "Science" },
                new Student() { Name = "Frank", Age = 24, grade = 92, ClassName = "Math" },
            };

            #region דוגמאות LINQ

            //---Linq Methods---
            //Max
            int maxGrade = students.Max((st) => st.grade);
            Console.WriteLine(maxGrade);
            double avg = students.Average(st => st.grade);
            //FirstOrDefault
            var stu = students.FirstOrDefault(st => st.Age > 23);
            //SingleOrDefault
            stu = students.SingleOrDefault(st => maxGrade == 100);
            //where
            List<Student> mathStudents = students.Where(student => student.ClassName == "Math").ToList();
            //where Query
            var ls=from student in mathStudents
                   where student.Name == "Alice"
                   select student.grade;


            //OrderBy
            students = students.OrderBy(x => x.grade).ToList();

            //Any
            bool found = students.Any(x => x.grade < 60);
            found = students.All(x=>x.grade > 60);
			//Select
            

			#endregion
			#endregion

			#region Test Monkey Exercise
			//השלמת תרגיל הקופים מהחומר הנלמד
            MonkeyList monkeys = new MonkeyList(); // יצירת אובייקט של רשימת הקופים

            try
            {
                // 1. הדפסת נתוני קוף לפי שם
                Monkey monkeyByName = monkeys.SearchMonkeyByName("Baboon");
                Console.WriteLine(monkeyByName);

                // 2. הדפסת כל הקופים לפי מיקום
                List<Monkey> monkeysByLocation = monkeys.GetAllMonkeysPerLocation("Africa & Asia");
                monkeysByLocation.ForEach(m => Console.WriteLine(m.Name));

                // 3. בדיקה אם יש קוף במיקום מסוים
                bool isMonkeyInLocation = monkeys.IsThereMonkeyInThatLocation("Japan");
                Console.WriteLine(isMonkeyInLocation);

                // 4. מיון לפי מיקום ושם
                List<Monkey> sortedMonkeys = monkeys.SortByLocattionAndName();
                sortedMonkeys.ForEach(m => Console.WriteLine($"{m.Location} - {m.Name}"));

                // 5. חיפוש קוף לפי שם (שימוש ב-LINQ)
                Monkey monkeyByNameQuery = monkeys.SearchMonkeyByNameQuery("Capuchin Monkey");
                Console.WriteLine(monkeyByNameQuery);

                // 6. הדפסת כל הקופים לפי מיקום (שימוש ב-LINQ)
                var monkeysByLocationQuery = monkeys.GetAllMonkeysPerLocationQuery("Central & South America");
                monkeysByLocationQuery.ForEach(m => Console.WriteLine(m.Name));

                // 7. מיון לפי מיקום ושם (שימוש ב-LINQ)
                var sortedMonkeysQuery = monkeys.SortByLocattionAndNameQuery();
                sortedMonkeysQuery.ForEach(m => Console.WriteLine($"{m.Location} - {m.Name}"));

                // 8. הדפסת מספר הקופים לפי מיקום
                monkeys.PrintNumberOfMonkeysPerLocation();

                // 9. הדפסת מספר הקופים לפי מיקום (שימוש ב-LINQ)
                monkeys.PrintNumberOfMonkeysPerLocationQuery();

                // 10. קבלת כל הקופים לפי שם
                var monkeysByNameArray = monkeys.GetAllMonkeysByName("Golden Lion Tamarin");
                foreach (var monkey in monkeysByNameArray)
                {
                    Console.WriteLine(monkey.Name);
                }

                // 11. יצירת מילון של קופים
                var monkeyDictionary = monkeys.CreateDictionaryFromMonkeyList();
                foreach (var kvp in monkeyDictionary)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.Name}");
                }

                // 12. בדיקה אם קוף קיים לפי שם (שימוש במילון)
                bool doesMonkeyExist = monkeys.MonkeExistByName("Mandrill");
                Console.WriteLine(doesMonkeyExist);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("TBD");
            }
			#endregion
		}
	}
}

