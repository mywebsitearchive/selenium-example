using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumDocs
{
    [TestClass]
    public class UsingSeleniumTest : BaseChromeTest
    {
        readonly string url = "https://mywebsitearchive.github.io/dailyschedule/";
        [TestMethod]
        public void AddTasks()
        {
            driver.Url = url;
            driver.Navigate().GoToUrl(url);

            var controls = driver.FindElement(By.Id("controls"));
            var input = driver.FindElement(By.Id("minuteinput"));
            var buttons = controls.FindElements(By.TagName("button"));
            
            var tasksBefore = driver.FindElements(By.CssSelector("#taskslist tr"));
            input.Click();
            input.SendKeys("10");
            buttons[0].Click();
            
            var tasksAfter = driver.FindElements(By.CssSelector("#taskslist tr"));
            Assert.AreNotEqual(tasksBefore.Count, tasksAfter.Count);
        }
        [TestMethod]
        public void RemoveTasks()
        {
            driver.Navigate().GoToUrl(url);
            var controls = driver.FindElement(By.Id("controls"));
            var input = driver.FindElement(By.Id("minuteinput"));
            var buttons = controls.FindElements(By.TagName("button"));
            
            // add tasks again since the localstorage was wiped
            input.Click();
            input.SendKeys("10");
            buttons[0].Click();
            
            var removeBtn = driver.FindElement(By.CssSelector("#taskslist tr button"));
            var tasksBefore = driver.FindElements(By.CssSelector("#taskslist tr"));
            removeBtn.Click();

            var tasksAfter = driver.FindElements(By.CssSelector("#taskslist tr"));
            Assert.AreNotEqual(tasksBefore.Count, tasksAfter.Count);
        } 
        [TestMethod]
        public void AddTodos()
        {
            driver.Navigate().GoToUrl(url);
            var btn = driver.FindElement(By.CssSelector("#b2"));
            var controlsButtons = driver.FindElements(By.CssSelector("#controls2 button"));

            // switch mode from navi
            btn.Click();

            var todosBefore = driver.FindElements(By.CssSelector("#todoslist tr"));

            // add a todo
            controlsButtons[0].Click();

            var todosAfter = driver.FindElements(By.CssSelector("#todoslist tr"));

            Assert.AreNotEqual(todosBefore.Count, todosAfter.Count);
        }
        [TestMethod]
        public void RemoveTodos()
        {
            driver.Navigate().GoToUrl(url);
            var btn = driver.FindElement(By.CssSelector("#b2"));
            var controlsButtons = driver.FindElements(By.CssSelector("#controls2 button"));

            // switch mode from navi
            btn.Click();

            // add a todo
            controlsButtons[0].Click();

            var todosBefore = driver.FindElements(By.CssSelector("#todoslist tr"));
            
            // open deletion dialog
            var deleteBtn = driver.FindElements(By.CssSelector("#todoslist tr button"))[1];
            deleteBtn.Click();

            // confirm deletion using dialog
            var confirmDeletion = driver.FindElement(By.CssSelector("#deletetodo"));
            confirmDeletion.Click();

            var todosAfter = driver.FindElements(By.CssSelector("#todoslist tr"));

            Assert.AreNotEqual(todosBefore.Count, todosAfter.Count);
        }
        [TestMethod]
        public void AddHabits()
        {
            driver.Navigate().GoToUrl(url);
            var btn = driver.FindElement(By.CssSelector("#b3"));
            var controlsButtons = driver.FindElements(By.CssSelector("#habitscontrols button"));

            // switch mode from navi
            btn.Click();

            var habitsBefore = driver.FindElements(By.CssSelector("#habitslist tr"));

            // add a habit
            controlsButtons[0].Click();

            var habitsAfter = driver.FindElements(By.CssSelector("#habitslist tr"));

            Assert.AreNotEqual(habitsBefore.Count, habitsAfter.Count);
        }
        [TestMethod]
        public void RemoveHabits()
        {
            driver.Navigate().GoToUrl(url);
            var btn = driver.FindElement(By.CssSelector("#b3"));
            var controlsButtons = driver.FindElements(By.CssSelector("#habitscontrols button"));

            // switch mode from navi
            btn.Click();

            // add a habit
            controlsButtons[0].Click();

            var habitsBefore = driver.FindElements(By.CssSelector("#habitslist tr"));
            
            // open deletion dialog
            var deleteBtn = driver.FindElements(By.CssSelector("#habitslist tr button"))[1];
            deleteBtn.Click();

            // confirm deletion using dialog
            var confirmDeletion = driver.FindElement(By.CssSelector("#confirmyes"));
            confirmDeletion.Click();

            var habitsAfter = driver.FindElements(By.CssSelector("#habitslist tr"));

            Assert.AreNotEqual(habitsBefore.Count, habitsAfter.Count);
        }
    }
}