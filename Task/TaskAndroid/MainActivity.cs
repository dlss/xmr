using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Porable.Lib;
using System.Collections.Generic;

namespace TaskAndroid
{
    [Activity(Label = "TaskAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TodoItemListAdapter taskList;
        IList<TodoItem> tasks;
        Button addTaskButton;
        ListView taskListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Main);

            //Find our controls
            taskListView = FindViewById<ListView>(Resource.Id.TaskList);
            addTaskButton = FindViewById<Button>(Resource.Id.AddButton);

            // wire up add task button handler
            if (addTaskButton != null)
            {
                addTaskButton.Click += (sender, e) => {
                    StartActivity(typeof(DetailsScreenActivity));
                };
            }

            // wire up task click handler
            if (taskListView != null)
            {
                taskListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
                    var taskDetails = new Intent(this, typeof(DetailsScreenActivity));
                    taskDetails.PutExtra("TaskID", tasks[e.Position].ID);
                    StartActivity(taskDetails);
                };
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            tasks = TaskyApp.Current.TodoManager.GetTasks();

            //create our adapter
            taskList = new TodoItemListAdapter(this, tasks);

            // Hook up our adapter to our ListView
            taskListView.Adapter = taskList;
        }
    }
}

