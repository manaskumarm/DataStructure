// See https://aka.ms/new-console-template for more information
using Demoabstraction;
using LinkedListImplementation;
using MyPractise;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

List<Dictionary<string, int>> MyList = new List<Dictionary<string, int>>();
MyList.Add(new Dictionary<string, int>()); // "Dictionary 1"
MyList.Add(new Dictionary<string, int>()); // "Dictionary 2"
MyList[0].Add("Dictionary 1", 1);
MyList[0].Add("Dictionary 2", 2);

MyList[1].Add("Dictionary 3", 3);
MyList[1].Add("Dictionary 2", 4);
MyList[1].Add("Dictionary 4", 4);

Dictionary<string, int> tempList = new Dictionary<string, int>();

foreach (var dictionary in MyList)
{
    foreach (var keyValue in dictionary)
    {
        try
        {
            tempList.Add(keyValue.Key, keyValue.Value);
        }
        catch (Exception)
        {
            dictionary.Remove(keyValue.Key);
        }

        Console.WriteLine(string.Format("{0} {1}", keyValue.Key, keyValue.Value));
    }
}

int t10 = 10;

static async Task getFilghtDataAsync()
{
    string jsonString = @"{
        'ErrorList':[
        {
            'message':'Sorry its too late'
        }]
    }";
    //Using the JSON-parse method here
    var getResult = JObject.Parse(jsonString);
    Console.WriteLine(getResult["ErrorList"][0]["message"]);

    var person = new Person("John Doe", "gardener");

    var json = @"{'firstname':'John Doe'}";//JsonConvert.SerializeObject(person);
    var data = new StringContent(json, Encoding.UTF8, "application/json");

    Console.WriteLine(data);

    HttpResponseMessage response = null;
    var url = new Uri("api url");
    try
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            //add apim key
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string body = @"jsondata....";
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            response = await client.PostAsync(url, content);
            string result = response.Content.ReadAsStringAsync().Result;// await response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
    }
}

getFilghtDataAsync();





Dictionary<string, object> flightData = new Dictionary<string, object>
    {
        { "PNR", "TOP09" },
        { "Class", "General" },
        { "SeatNumber", "1K" },
        { "CheckinCity", "Udala" },
        { "VisaCheckRequired", false }
    };
Dictionary<string, Dictionary<string, object>> flightDictionary =
    new Dictionary<string, Dictionary<string, object>>
    {
        { "verfication_data", flightData }
    };

static object GetFlightProps(Dictionary<string, Dictionary<string, object>> flightDictionary, string key)
{
    return flightDictionary["verfication_data"][key];
}


var temp = GetFlightProps(flightDictionary, "PNR");


var t = new PriorityQueue();
t.Enqueue(1);
t.Enqueue(4);
t.Enqueue(6);
t.Enqueue(8);
t.Enqueue(3); t.Enqueue(5); t.Enqueue(2);
var t2 = t.Dequeue();

Permutation.Execute();

baseClass obj = new baseClass();
SqaureRoot.squareRoot(9329393, 4);
baseClass obj4 = new baseClass();
SqaureRoot.squareRoot(9329393, 4);

FindSquareRoot_BS(9329393);




NQueenBackTrackImpl.Run();
square_root(4);


// invokes the method 'show()'
// of class 'baseClass'
obj.show();

obj = new derived();
// it also invokes the method
// 'show()' of class 'baseClass'
obj.show();

var obj2 = new derived();
// it also invokes the method
// 'show()' of class 'baseClass'
obj2.show();

Hashtable mySet = new Hashtable();
// Inserting elements in HashSet
mySet.Add(1, "s");

static void ConsolePrint(int i, int j)
{
    Console.WriteLine(i);
}

static void Main(string[] args)
{
    Action<int, int> printActionDel = ConsolePrint;
    printActionDel(10, 12);
}

static double square_root(double myNumber)
{
    double precision = 0.00001;
    double low = 0;
    double high = myNumber;
    double mid = 0;
    int counter = 0;
    while ((high - low) > precision)
    {
        counter++;
        mid = (double)((low + high) / 2);
        if ((mid - precision) >= mid * mid && mid * mid <= (precision + mid))
        {
            break;
        }
        else if (mid * mid < myNumber)
        {
            low = mid;
        }
        else
        {
            high = mid;
        }
    }
    return mid;

}

static float FindSquareRoot_BS(int number)
{
    float precision = 0.0001f;
    float min = 0;
    float max = number;
    float result = 0;
    int counter = 0;

    while (max - min > precision)
    {
        counter++;
        result = (min + max) / 2;
        if ((result * result) >= number)
        {
            max = result;
        }
        else
        {
            min = result;
        }
    }
    Console.WriteLine("counter{0}", counter);
    return result;
}



int[] A = { 5, 0, 0, 4, 6, 0 };
int n = A.Length;
int j = 0;
int index = 0;
//for (int i = 0; i < n; i++)
//{
//    if (A[i] != 0)
//    {
//        int temp = A[j];
//        A[j] = A[i];
//        A[i] = temp;
//        j++;
//    }   
//}
//for (int i = 0; i < n; i++)
//{
//    Console.Write(A[i]);
//    Console.Write(" ");
//}

static bool isSubsetSum(int[] set, int n, int sum)
{
    // Base Cases
    if (sum == 0)
        return true;
    if (n == 0)
        return false;

    // If last element is greater than sum,
    // then ignore it
    if (set[n - 1] > sum)
        return isSubsetSum(set, n - 1, sum);

    /* else, check if sum can be obtained 
    by any of the following
    (a) including the last element
    (b) excluding the last element */
    return isSubsetSum(set, n - 1, sum) || isSubsetSum(set, n - 1, sum - set[n - 1]);
}



int[] set = { 4, 3, 2 };
int sum = 6;
int n1 = set.Length;

if (isSubsetSum(set, n1, sum) == true)
    Console.WriteLine("Found a subset with given sum");
else
    Console.WriteLine("No subset with given sum");

new HelperSLL().Add();

new NQueenBackTrack().NQueenProb();






namespace Demoabstraction
{
    struct Student
    {
        //Variables 'Roll_no', 'Name' and 'Mobile' are initialised with value which is not possible in struct.  
        //It will produce a compile error as "Program.Student cannot have instance property or field initializers in structs"  
        public int Roll_no;
        public string Name;
        public string Mobile;
    }

    public class emp
    {
        public int MyProperty { get; set; }
    }

    public class testclass
    {
        public int eid { get; set; }
        public string ename { get; set; }
        public double salary { get; set; }
    }

    class MyClass
    {
        public static void GetFun()
        {



            Student student = new Student();
            student.Roll_no = 1;
            student.Name = "";

            List<testclass> tc2 = new List<testclass>()
            {
                new testclass(){ ename = "gdhd"},
                new testclass(){ename ="dd"}
            };

            ICollection<testclass> tc = tc2;

            string[] monthsofYear =
                {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };

            //casted to ICollection  
            ICollection<string> collection = monthsofYear;
            collection.Add("test");
            (collection as string[])[2] = "Financial Month";
            if (!collection.IsReadOnly)
            {
                collection.Add("Financials");
            }
            else
            {
                Console.WriteLine("readonly collection");
            }
            foreach (var month in collection)
            {
                Console.WriteLine(month);
            }
        }
    }



    abstract public class ShapesClass
    {
        abstract public int Area();

        virtual public int Area2()
        {
            return 6;
        }
    }

    class A
    {
        public void Test() { Console.WriteLine("A::Test()"); }
    }

    class B : A
    {
        public void Test() { Console.WriteLine("B::Test()"); }
    }

    class C : B
    {
        public new void Test() { Console.WriteLine("C::Test()"); }
    }


    class baseClass
    {
        public baseClass()
        {

        }

        public void show()
        {
            Console.WriteLine("Base class");
        }
    }

    // derived class name 'derived'
    // 'baseClass' inherit here
    class derived : baseClass
    {
        // overriding
        public void show()
        {
            Console.WriteLine("Derived class");
        }
    }

    public class temp
    {
        public string id;
    }

    class GFG
    {
        // Main Method
        public static void Main()
        {
            // 'obj' is the object of
            // class 'baseClass'
            baseClass obj = new baseClass();


            // invokes the method 'show()'
            // of class 'baseClass'
            obj.show();

            derived obj1 = new derived();

            // it also invokes the method
            // 'show()' of class 'baseClass'
            obj1.show();
        }
    }
}