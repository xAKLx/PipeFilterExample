//using PipesFilter;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;

//namespace PipesFilterExample
//{
//    class Program2
//    {
//        static bool IsMale(Student target)
//        {
//            return target.IsMale;
//        }

//        static bool MatriculaCondition(Student target)
//        {
//            return (target.Matricula < 20100000);
//        }

//        static void RunFilter(AFilter filter)
//        {
//            new Thread(new ThreadStart(filter.Run)).Start();

//        }

//        static void BackupMain(string[] args)
//        {
//            var studentList = new List<Student>();
//            studentList.Add(new Student("Juan",20124567, 21, true));
//            studentList.Add(new Student("Jeferson", 20094567, 21, true));
//            studentList.Add(new Student("Estibalis", 20134567, 21, false));
//            studentList.Add(new Student("Carla", 20124367, 21, false));
//            studentList.Add(new Student("Maria", 20094563, 21, false));
//            studentList.Add(new Student("Milagros", 20084777, 21, false));

//            var pipe1 = new Pipe<ICollection<Student>>(10);
//            var pipeFemale = new Pipe<ICollection<Student>>(10);
//            var pipeMale = new Pipe<ICollection<Student>>(10);
//            var pipeFemale2 = new Pipe<ICollection<Student>>(10);
//            var mergePipe = new Pipe<ICollection<Student>>(10);
//            var sortPipe = new Pipe<List<Student>>(10);

//            var filterSplitMF = new Condition2PipeFilter<Student>(pipe1);
//            filterSplitMF.addCondition2Pipe(IsMale, pipeMale);
//            filterSplitMF.ElseOutputPipe = pipeFemale;

//            var filterSplitMenor2010 = new Condition2PipeFilter<Student>(pipeFemale);
//            filterSplitMenor2010.addCondition2Pipe(MatriculaCondition, pipeFemale2);

//            var merger = new MergerFilter<Student>(mergePipe);
//            merger.AddInputPipe(pipeFemale2);
//            merger.AddInputPipe(pipeMale);

//            var sorter = new SortFilter<Student>(mergePipe, sortPipe);

//            RunFilter(filterSplitMF);
//            RunFilter(filterSplitMenor2010);
//            RunFilter(merger);
//            RunFilter(sorter);

//            pipe1.AddData(studentList);

//            ICollection<Student> list;

//            do
//            {
//                list = sortPipe.getData();

//            } while (list == null);

//            String toConsole;
//            foreach (var student in list)
//            {
//                toConsole = student.Matricula + "  " + student.Name + "  " + student.Age.ToString() + "  ";

//                if (student.IsMale)
//                    toConsole += "Male";
//                else
//                    toConsole += "Female";

//                Console.WriteLine(toConsole);
//            }
//        }
//    }
//}
