using TaskManagerApp;
using Task = TaskManagerApp.Task;

namespace TaskManagerAppTesting
{
    [TestFixture]
    public class TaskManagerAppTesting
    {
        private TaskManager _taskManager;

        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
            _taskManager.setUserFilePath("12345678");
            _taskManager.JsonFileReader();

        }

        [Test]
        public void AddTask_ShouldAddTaskToDictionary()
        {
            // Arrange
            var task = new Task(taskID: "123456", title: "Test Task", description: "This is a test", priority: "High", duedate: "2024-12-31");

            // Act
            _taskManager.addTasks(task);

            // Assert
            var retrievedTask = _taskManager.getTask("123456");

            Assert.That(retrievedTask, Is.Not.Null);
            Assert.That("123456", Is.EqualTo(retrievedTask.getTaskID()));
            Assert.That("Test Task", Is.EqualTo(retrievedTask.getTitle()));
            Assert.That("This is a test", Is.EqualTo (retrievedTask.getDescription()));
            Assert.That("High", Is.EqualTo(retrievedTask.getPriority()));
            Assert.That("2024-12-31", Is.EqualTo(retrievedTask.getDueDate()));


        }



        [Test]
        public void DeleteTask_ShouldRemoveTaskFromDictionary()
        {
            // Arrange
            var task = new Task(taskID: "654321", title: "Task to Delete", description: "Description", priority: "Medium", duedate: "2024-11-30");
            _taskManager.addTasks(task);

            // Act
            _taskManager.deleteTask(task);

            // Assert
            var deletedTask = _taskManager.getTask("654321");
            Assert.That(deletedTask, Is.Null);
        }
    }
}