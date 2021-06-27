namespace Netologia_2_2
{
    /// <summary>
    /// Структура, описывающая предмет в игре
    /// </summary>
    public struct Item
    {
        public string Name;
        public ulong ID;
        public string Description;
        public ItemProperty Property;

        /// <summary>
        /// Переопределение базового метода для удобства сравнения
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>Результат сравнения</returns>
		public override bool Equals(object obj)
		{
            //Если не переопределить Equals() для структуры,
            //то сравнение будет проходить по значению,
            //то есть каждое поле структуры будет сравниваться через рефлексию,
            //что сильно бьет по производительности
            return obj is Item && ((Item)obj).ID == ID;
		}

        //Благодаря этим методам можно написать следующий код:
        //Item a = new Item();
        //Item b = new Item();
        //if(a == b) Console.WriteLine("Структуры равны");
        //if(a != b) Console.WriteLine("Структуры НЕ равны");
        public static bool operator==(Item a, Item b)
        {
            return a.Equals(b);
		}

        public static bool operator !=(Item a, Item b)
        {
            return !a.Equals(b);
        }
    }

    /// <summary>
    /// Структура, описывающая предмет одеяния персонажа
    /// </summary>
    public struct Equipment
    {
        public EquipmentItemType Type;
        public Item Item;

		public override bool Equals(object obj)
		{
            return obj is Equipment && ((Equipment)obj).Equals(Item);
		}

        public static bool operator ==(Equipment a, Equipment b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Equipment a, Equipment b)
        {
            return !a.Equals(b);
        }
	}

    /// <summary>
    /// Класс, который содержит эффект и длительность его действия
    /// </summary>
    public class EffectData
    {
        /// <summary>
        /// Длительность действия эффекта
        /// </summary>
        public float Duraction;
        /// <summary>
        /// Цель, на которую действует эффект
        /// </summary>
        public Controller Target;
        /// <summary>
        /// Источник, юнит, наложивший эффект
        /// </summary>
        public Controller Source;
        /// <summary>
        /// Описание эффекта
        /// </summary>
        public Effect Effect;
	}

    //Структура-заглушка, логика в ней, для данного ДЗ не требуется
    //Внутри содержится информация, как изменяются параметры персонажа под этим эффектом
    //они могут повышаться, если это баф, или понижаться, если это дебаф
    public struct Effect { }
}