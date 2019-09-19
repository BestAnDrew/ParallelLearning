using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ParallelLearning
{
    class Program
    {
        static int count = 0;

        static object baton = new object();
        static void Main(string[] args)
        {
            //微软官方帮助文档：https://docs.microsoft.com/en-us/azure/devops/repos/git/gitquickstart?view=azure-devops&tabs=visual-studio
            //如何增加Github用你的Visual Studio:https://www.youtube.com/watch?v=Nw2tfO44_9E
            //同步-同步：是指拉取远程仓库的更改（Fetch），然后尝试将这些更改添加到您本地的分支中。同时将保留本地修改的历史纪录.合并的挑战是从fetch与您的分支上的现有未刷新提交的冲突中获取提交。Git通常非常聪明地自动解决合并冲突，
            //     但有时您必须手动解决合并冲突并使用新的合并提交完成合并。
            //同步-提取：仅仅是拉取远程仓库的更改到窗体上，是否合并需要你审阅后决定
            //同步-拉取：简单粗暴，直接将远程仓库的更改添加到你的本地分支，直接将你的本地分支与远程保持一致
            //for (int i = 0; i < 8; i++)
            //{
            //    var thread = new Thread(Different);
            //    thread.Start(i);
            //}
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //for (int i = 0; i < Environment.ProcessorCount; i++)
            //{
            //    var thread = new Thread(Different);
            //    thread.IsBackground = true;
            //    thread.Start(i);
            //}


            //Console.WriteLine("Leaving main");
            //Console.Read();

            var thread1 = new Thread(IncrementCount);
            var thread2 = new Thread(IncrementCount);


            bool lockToken = false;
            Monitor.Enter(baton,ref lockToken);
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if(lockToken)
                    Monitor.Exit(baton);

            }


            foreach (int i in Yeildbreak())
                Console.WriteLine(i);


            Expression<Func<int, bool>> test = i => i < 5;
            
            Console.Read();

        }
        static Random rand = new Random();
        private static IEnumerable<int> Yeildbreak()
        {
            while (true)
            {
                var num = rand.Next(10);
                if (num % 100 == 0)
                    yield break;
                yield return num;


            }
        }

        static void IncrementCount()
        {
            while (true)
            {
                count++;
                Console.WriteLine("ThreadID = "+Thread.CurrentThread.ManagedThreadId
                                  +"Increment Count to = " + count);
            }
        }
        static void Different(Object ThreadID)
        {
            while (true)
                Console.WriteLine("hello from Different Method" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
