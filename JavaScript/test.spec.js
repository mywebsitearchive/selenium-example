import { By, Builder} from 'selenium-webdriver';
import { deepStrictEqual } from "assert";


describe('Add tasks', function () {
  let driver;
  
  before(async function () {
    driver = new Builder()
      .forBrowser('chrome')
      .build();
  });

  after(async () => await driver.quit());

  it('can add tasks to #taskslist', async function () {

    await driver.get('https://mywebsitearchive.github.io/dailyschedule/');
    const controls = await driver.findElement(By.id("controls"));
    const input = await driver.findElement(By.id("minuteinput"));
    const buttons = await controls.findElements(By.tagName("button"));

    const tasksBefore = await driver.findElements(By.css("#taskslist tr"));
    
    await driver.actions()
      .click(input)
      .sendKeys("1")
      .sendKeys("0")
      .click(buttons[0])
      .perform();

    const tasksAfter = await driver.findElements(By.css("#taskslist tr"));

    deepStrictEqual(await tasksBefore.length == 0 && await tasksAfter.length > 0, true);
  });

  it('can remove tasks from the list', async function () {
    const removeBtn = await driver.findElement(By.css("#taskslist tr button"));
    const tasksBefore = await driver.findElements(By.css("#taskslist tr"));

    await driver.actions()
      .click(removeBtn)
      .perform();

    const tasksAfter = await driver.findElements(By.css("#taskslist tr"));

    deepStrictEqual(await tasksBefore.length > 0 && await tasksAfter.length == 0, true);
  });

  it('can add todos to #todoslist', async function () {
    const b2 = await driver.findElement(By.css("#b2"));

    await driver.actions()
      .click(b2)
      .perform();

    const controls = await driver.findElement(By.id("controls2"));
    const buttons = await controls.findElements(By.tagName("button"));
    const todosBefore = await driver.findElements(By.css("#todoslist tr"));

    await driver.actions()
      .click(buttons[0])
      .perform();

    const todosAfter = await driver.findElements(By.css("#todoslist tr"));

    deepStrictEqual(await todosBefore.length == 0 && await todosAfter.length > 0, true);
  });

  it('can remove todos from the list', async function () {
    const todosBtns = await driver.findElements(By.css("#todoslist tr button"));
    const todosBefore = await driver.findElements(By.css("#todoslist tr"));

    // open deletion dialog
    await driver.actions().click(todosBtns[1]).perform();

    const deleteTodoBtn = await driver.findElement(By.css("#deletetodo"));
    await driver.sleep(200);

    // click dialog
    await driver.actions().click(deleteTodoBtn).perform();

    const todosAfter = await driver.findElements(By.css("#todoslist tr"));

    deepStrictEqual([await todosBefore.length, await todosAfter.length], [1, 0]);
  });

  it('can add habits to #habitslist', async function () {
    const b3 = await driver.findElement(By.css("#b3"));

    // wait until message alert goes away
    await driver.sleep(1000);

    await driver.actions()
      .click(b3)
      .perform();


    const controls = await driver.findElement(By.id("habitscontrols"));
    const buttons = await controls.findElements(By.tagName("button"));
    const habitsBefore = await driver.findElements(By.css("#habitslist tr"));

    await driver.actions()
      .click(buttons[0])
      .perform();

    const habitsAfter = await driver.findElements(By.css("#habitslist tr"));

    deepStrictEqual(await habitsBefore.length == 0 && await habitsAfter.length > 0, true);
  });

  it('can remove habits from the list', async function () {
    const habitsBtns = await driver.findElements(By.css("#habitslist tr button"));
    const habitsBefore = await driver.findElements(By.css("#habitslist tr"));

    // open deletion dialog
    await driver.actions().click(habitsBtns[1]).perform();

    const deleteHabitBtn = await driver.findElement(By.css("#confirmyes"));

    // click dialog
    await driver.actions().click(deleteHabitBtn).perform();

    const habitsAfter = await driver.findElements(By.css("#habitslist tr"));

    deepStrictEqual((await habitsBefore).length > 0 && (await habitsAfter).length == 0, true);
  });
});
