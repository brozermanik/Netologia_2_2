namespace Netologia_2_2
{
    /// <summary>
    /// Типы экипировки
    /// </summary>
    public enum EquipmentItemType : byte
    {
        /// <summary>
        /// Шлем
        /// </summary>
        Helm = 0,
        /// <summary>
        /// Броня
        /// </summary>
        Armor = 1,
        /// <summary>
        /// Правая рука
        /// </summary>
        RightHand = 2,
        /// <summary>
        /// Левая рука
        /// </summary>
        LeftHand = 3,
        /// <summary>
        /// Двуручный предмет
        /// </summary>
        TwoHanded = 4,
        /// <summary>
        /// Штаны
        /// </summary>
        Pants = 5,
        /// <summary>
        /// Ботинки
        /// </summary>
        Boots = 6,
        /// <summary>
        /// Первое кольцо
        /// </summary>
        Ring1 = 7,
        /// <summary>
        /// Второе кольцо
        /// </summary>
        Ring2 = 8
    }

    /// <summary>
    /// Типы противников в игре
    /// </summary>
    public enum EnemyType : byte
    {
        /// <summary>
        /// Слабый бандит
        /// </summary>
        WeakBandit,
        /// <summary>
        /// Средний бандит
        /// </summary>
        MediumBandit,
        /// <summary>
        /// Лидер бандитов
        /// </summary>
        BanditLeader,
        /// <summary>
        /// Волк
        /// </summary>
        Wolf,
        /// <summary>
        /// Матерый волк
        /// </summary>
        SeasonedWolf,
        /// <summary>
        /// Скелет-мечник
        /// </summary>
        SkeletonSwordsman,
        /// <summary>
        /// Скелет-луычник
        /// </summary>
        SkeletonArcher,
        /// <summary>
        /// Лич
        /// </summary>
        Lich,
    }

}