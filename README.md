# Converter
Windows Forms project by: Filip Danilovski
## 1. Опис на апликација
Апликацијата што ја развивав е конверзија на валути и мерни единици. Преку неа може да се претвараат вредности на една мерна единица во друга од типови како должина, маса, време, пренос на податоци (Data Transfer Rate), како и валути чии вредности се вадат од интернет преку `API (Application Programming Interface)` на секоја минута.
## 2. Упатство за користење
Апликацијата има еден прозорец на кој се понудени три `dropdown` листи со кои се бираат посакуваните мерни единици за конверзија. Дадено е текст поле во кое се внесува посакуваната вредност и се стиснува на копчето `Convert`, со што доколку е успешна конверзијата ќе се прикаже резултатот од неговата десна страна.

![Converter Windows Form Design](/Screenshot1.png)

Во случај на корисничка грешка, воведени се валидациски провајдери за грешки кои ќе го известат корисникот каде се наоѓа грешката, како на пример:
* Корисникот нема да може да ја искористи функцијата на копчето `Convert` доколку сите полиња не се пополнети.

 ![Converter Windows Form Design](/Screenshot2.png)

* Корисникот нема да може да направи манипулација на селектираните вредности од листа со цел да прави конверзија на мерни единици кои не се од ист тип.

 ![Converter Windows Form Design](/Screenshot3.png)

* Корисникот нема да може да внесе вредност во даденото текст поле која не претставува цел или децимален број.

 ![Converter Windows Form Design](/Screenshot4.png)

Постои и копче `Swap` со кое корисникот може лесно да ги замени избраните мерни единици и да врши конверзија во обратна насока. Во долно-десниот агол е поставена лабела која му го кажува на корисникот статусот на вадените податоци за валути од интернет.
## 3. Решение на проблемот
За решение на проблемот главните функции и податоци се чуваат во класата `ConverterClass`, каде што се користи податочна структура `Dictionary`. `Key` на овој `Dictionary` е `string` кој го претставува името на типот на мерни единици, додека `Value` е листа од објекти од помошна класа `Unit` - `List<Unit>`. Во помошната класа `Unit` се чуваат две променливи - една за името на мерната единица, а друга за ратата на конверзија која ќе се користи во формулата за пресметување во функција `convert()`. Во конструкторот на класата `ConverterClass` се додаваат мерните единици во направениот `Dictionary`.
За пополнување на dropdown листите, во класата `ConverterClass` се направени три функции:
* За листање на типовите на мерни единици
```
public List<String> getUnitTypes() 
{
    return unitsDictionary.Keys.ToList();
}
```
* За листање на мерните единици за даден тип
```
public List<Unit> getUnits(String unitType) 
{
    return unitsDictionary[unitType];
}
```
* За додавање на тип на мерна единица во `Dictionary` без да се појави дуплирање
```
public void addUnits(string name, List<Unit> listUnits)
{
    if (unitsDictionary.ContainsKey(name))
        unitsDictionary.Remove(name);
    unitsDictionary.Add(name, listUnits);
}
```
Покрај овие три функции, во класата е ставена и главната функција за вршење на конверзија а тоа е `convert()` функцијата:
```
public double convert(String fromUnit, String toUnit, double value, string selectedUnitType) 
{
    double tempMultiplier = 0;
    double tempDenominator = 0;
    foreach (Unit unit in unitsDictionary[selectedUnitType])
    {
        if (unit.name == fromUnit)
            tempMultiplier = unit.multiplier;
        if (unit.name == toUnit)
            tempDenominator = unit.multiplier;
    }
    if (tempMultiplier == 0 || tempDenominator == 0)
        throw new ArgumentException("Unit not available");
    return value * tempMultiplier / tempDenominator;
}
```
Во оваа функција користиме четири параметри. Со помош на `selectedUnitType` ја пребаруваме соодветната листа од `Dictionary` со foreach со цел доколку најдеме објект со иста name променлива да ја доделиме вредноста на ратата на конверзија на тој објект соодветно на променливите `tempMultiplier` (за `name==fromUnit`) и `tempDenominator` (за `name==toUnit`). Ратата на конверзија е доделувана при креирање на објектите со логика на земање за една мерна единица како основна, а останатите споредени со неа. Ова го правиме за да заштедиме меморија со тоа што нема да ги пишуваме ратите на конверзија за секој пар мерни единици посебно. Со таа логика на добивање на резултат ја пишуваме формулата `value * tempMultiplier / tempDenominator` која ќе ни го врати точниот резултат за извршување на дадена конверзија. Пред да го вратиме резултат се осигуруваме дека мерните единици кои ги бараме се навистина наоѓаат во нивните соодветни листи.

Како последна класа е направена класата `CurrencyService`, која служи за влечење на податоци од интернет за валути. Во неа има една функција `getCurrencies()` која преку `API` од страната https://www.exchangerate-api.com/ ги превзема најновите курсни листи и ги враќа во листа.
```
string URL = "https://v6.exchangerate-api.com/v6/ed1b90d3840884137fbb7f9e/latest/USD";
HttpClient client = new HttpClient();
public async Task<List<Unit>> getCurrencies()
{
    string result = await client.GetStringAsync(URL);
    JObject jObject = JObject.Parse(result);
    List<Unit> listUnits = new List<Unit>();
    foreach(JProperty property in jObject["conversion_rates"])
    {
        Unit unitObject = new Unit(property.Name, Double.Parse(property.Value.ToString()));
        listUnits.Add(unitObject);
    }
    return listUnits;
}
```
Потоа таа листа се користи во функцијата на алатката `backgroundWorker` со која ги додаваме добиените вредности во `Directory` од класата `ConverterClass`. Додатно се направени различни акции за различен статус на податоците за валути.
```
private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
{
    lbStatus.Invoke(new Action(() => {
        lbStatus.Text = "Loading currencies...";
        lbStatus.ForeColor = Color.Yellow;
    }));
    try
    {
        List<Unit> listCurrencies = await currencyService.getCurrencies();
        converter.addUnits("Currency", listCurrencies);
        cbUnit.Invoke(new Action(() => {
            int tempUnitIndex = cbUnit.SelectedIndex;
            int tempFromIndex = cbFrom.SelectedIndex;
            int tempToIndex = cbTo.SelectedIndex;
            cbUnit.Items.Clear();
            foreach (String item in converter.getUnitTypes())
                cbUnit.Items.Add(item);
            cbUnit.SelectedIndex = tempUnitIndex;
            cbFrom.SelectedIndex = tempFromIndex;
            cbTo.SelectedIndex = tempToIndex;
        }));
    }
    catch
    {
        lbStatus.Invoke(new Action(() => {
            lbStatus.Text = "Loading currencies failed";
            lbStatus.ForeColor = Color.Red;
        }));
    }
}
```
```
private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
    lbStatus.Invoke(new Action(() => {
        lbStatus.Text = "Loaded currencies at " + DateTime.Now.ToString("hh:mm:ss");
        lbStatus.ForeColor = Color.Green;
    }));
}
```

## 4. Тестови
За четирите функции од класата `ConverterClass` (`getUnitTypes()`, `getUnits()`, `addUnits()`, `convert()`) се направени по еден `Unit Test` за секој од нив. Сите тестови враќаат успешен резултат.

![Successful Tests](/Screenshot5.png)