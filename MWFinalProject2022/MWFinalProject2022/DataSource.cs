using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MWFinalProject2022
{
    static class DataSource
    {
        private static List<User> myUsers = new List<User>();
        public static ObservableCollection<Task> myTasks = new ObservableCollection<Task>();

        public static bool AddUser(User usr)
        {
            foreach (User user in myUsers)
            {
                if (usr.Username == user.Username)
                {
                    return false;
                }
            }
            myUsers.Add(usr);
            return true;
        }

        public static bool Login(string username, string password)
        {
            foreach (User user in myUsers)
            {
                if (user.Username == username)
                {
                    if (user.Password == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool AddTask(Task tsk)
        {
            foreach (Task task in myTasks)
            {
                if (task.TaskId == tsk.TaskId)
                {
                    return false;
                }
            }
            myTasks.Add(tsk);
            return true;
        }

        public static ObservableCollection<Task> GetTasks()
        {
            return myTasks;
        }

        public static List<User> GetUsers()
        {
            return myUsers;
        }

        public static int UserIndex(string username)
        {
            foreach (User usr in myUsers)
            {
                if (usr.Username == username)
                {
                    return myUsers.IndexOf(usr);
                }
            }

            return -1;
        }

        static public async Task<bool> DeleteTask(string id)
        {
            foreach (Task task in myTasks)
            {
                if (task.TaskId == id)
                {
                    myTasks.Remove(task);
                    return true;
                }
            }
            return false;
        }

        static public async Task<bool> EditTask(Task tsk)
        {
            foreach (Task task in myTasks)
            {
                if (task.TaskId == tsk.TaskId)
                {
                    myTasks[myTasks.IndexOf(task)] = tsk;
                    return true;
                }
            }
            return false;
        }
    }
}
