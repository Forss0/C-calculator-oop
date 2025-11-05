
using System;
using System.Collections.Generic;

abstract class MusicalInstrument
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public string HistoryText { get; protected set; }

    public MusicalInstrument(string name, string desc, string history)
    {
        Name = name;
        Description = desc;
        HistoryText = history;
    }

    public virtual void Show() => Console.WriteLine($" Інструмент: {Name}");
    public virtual void Desc() => Console.WriteLine($" Опис: {Description}");
    public virtual void History() => Console.WriteLine($" Історія: {HistoryText}");
}

// --- 4 потрібні інструменти ---
class Guitar : MusicalInstrument
{
    public Guitar() : base("Гітара", "Струнний щипковий інструмент з 6 струнами.", "Сучасна форма з’явилася в Іспанії у XIX столітті.") { }
}

class Piano : MusicalInstrument
{
    public Piano() : base("Фортепіано", "Клавішно-струнний інструмент з широким діапазоном звуків.", "Винайдено в Італії у 1709 році Бартоломео Крістофорі.") { }
}

class Drum : MusicalInstrument
{
    public Drum() : base("Барабан", "Ударний інструмент, який задає ритм.", "Найдавніший інструмент, відомий ще з часів давніх цивілізацій.") { }
}

class Synthesizer : MusicalInstrument
{
    public Synthesizer() : base("Синтезатор", "Електронний інструмент, що створює звуки різних тембрів.", "З’явився у XX столітті з розвитком електроніки.") { }
}

class OrchestraDemo
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<MusicalInstrument> orchestra = new List<MusicalInstrument>
        {
            new Guitar(),
            new Piano(),
            new Drum(),
            new Synthesizer()
        };

        Console.WriteLine("===  Оркестр інструментів ===\n");

        foreach (var instrument in orchestra)
        {
            instrument.Show();
            instrument.Desc();
            instrument.History();
            Console.WriteLine("-----------------------------");
        }
    }
}
