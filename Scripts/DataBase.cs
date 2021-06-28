using System;
using Netologia_2_2;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class DataBase : MonoBehaviour
{
    public const int c_INVENTORY_CAPACITY = 100;
    
    private List<EffectData> effectsBase = new List <EffectData>();
    private List<EnemyController> enemiesBase = new List<EnemyController>();
    private Dictionary<int, string> inventoryBase = new Dictionary<int, string>();

    private Dictionary<int, string> equiptmentBase = new Dictionary<int, string>();

    #region Effects Data

    /// <summary>
    /// Добавление нового эффекта 
    /// </summary>
    /// <param name="data">Добавляемый эффект</param>
	public void AddEffect(EffectData data)
    {
	    effectsBase.Add(data);
	}

    /// <summary>
    /// Попытка удалить эффект из коллекции эффектов
    /// </summary>
    /// <param name="data">Удаляемый эффект</param>
    /// <returns>Успешна-ли операция</returns>
    public bool TryToRemoveEffect(EffectData data)
    { 
	    var isRemoved = effectsBase.Remove(data);
	    return isRemoved;
    }

    /// <summary>
    /// Удаление эффектов, наложенных на определенную цель
    /// </summary>
    /// <param name="target">Цель, с которой удаляются все эффекты</param>
    public void RemoveAllEffectOnTarget(Controller target)
    {
	    effectsBase.RemoveAll( e => e.Target = target);
    }

    /// <summary>
    /// Удаление эффектов, наложенных на других, каким-то источником
    /// </summary>
    /// <param name="source">Источник эффектов</param>
    public void RemoveAllEffectsBySource(Controller source)
    {
	    effectsBase.RemoveAll( e => e.Source = source);
    }

    /// <summary>
    /// Возвращает все эффекты на какой-то целе
    /// </summary>
    /// <param name="target">Цель, эффекты, наложенные на которую, нужно вернуть</param>
    /// <returns>Коллекция эффектов</returns>
    public IEnumerable<EffectData> FindAllEffectsOnTarget(Controller target)
    {
	    return effectsBase.FindAll(e => e.Target == target);
    }

    /// <summary>
    /// Возвращает все эффекты, которые наложил какой-то источник
    /// </summary>
    /// <param name="target">Источник, который наложил эффекты на других персонажей</param>
    /// <returns>Коллекция эффектов</returns>
    public IEnumerable<EffectData> FindAllEffectsBySource(Controller source)
    {
	    return effectsBase.FindAll(e => e.Source == source);
    }

    /// <summary>
    /// Здесь каждый кадр нужно уменьшать время существование всех эффектов,
    /// если длительность эффекта закончилась, то эффект должен удалиться из коллекции
    /// </summary>
    /// 
    private void Update()
	{
	}

	#endregion

	#region Enemies Data

    /// <summary>
    /// Добавление в коллекцию нового противника
    /// </summary>
    public void AddEnemy(EnemyController enemy)
    {
	    enemiesBase.Add(enemy);
	}

    /// <summary>
    /// Удаление противника из отслеживания
    /// </summary>
    public void RemoveEnemy(EnemyController enemy)
    {
	    enemiesBase.Remove(enemy);
	}

    /// <summary>
    /// Добавление группы противников
    /// </summary>
    public void AddEnemies(IEnumerable<EnemyController> enemies)
    {
	    enemiesBase.AddRange(enemies);
	}

    /// <summary>
    /// Удаление группы противников
    /// </summary>
    public void RemoveEnemies(IEnumerable<EnemyController> enemies)
    {
	    foreach (var enemyController in enemies) enemiesBase.Remove(enemyController);
    }

    /// <summary>
    /// Возвращает всех противников определенного типа
    /// </summary>
    /// <param name="type">Тип противников</param>
    /// <returns>Коллекция типовых противников</returns>
    public IEnumerable<EnemyController> GetAllEnemiesByType(EnemyType type)
    {
	    var allEnemies = enemiesBase.Where(e => e.Type == type);
	    return allEnemies;
    }

    /// <summary>
    /// Поиск самого ближайшего противника к юниту
    /// </summary>
    /// <param name="unit">Юнит</param>
    /// <returns>Искомый противник</returns>
    public EnemyController GetNearestEnemy(Controller unit)
    {
    }

    /// <summary>
    /// Поиск всех противников в радиусе вокруг юнита
    /// </summary>
    /// <param name="radius">Радиус, вокруг которого происходит поиск</param>
    /// <param name="unit">Юнит, находящийся в центре окружности поиска</param>
    /// <returns>Список всех противников, стоящих достаточно близко</returns>
    public IEnumerable<EnemyController> GetEnemiesInRadius(float radius, Controller unit)
    {
    }

    /// <summary>
    /// Добавление эффектов на юнитов, стоящих в определенной отдаленности от источника 
    /// </summary>
    /// <param name="effect">Шаблон накладываемого эффекта</param>
    /// <param name="radius">Расстояние от цели до границы наложения эффекта</param>
    /// <param name="source">Центральный юнит, накладывающий эффекты</param>
    public void AddEffectInRadius(EffectData effect, float radius, Controller source)
    {
	}

    /// <summary>
    /// Возвращает всех противников определенных типов
    /// </summary>
    /// <param name="typeы">Коллекция типов противников</param>
    /// <returns>Коллекция типовых противников</returns>
    /// <remarks>Запись (params EnemyType[] types) означает, что в качестве аргументов может быть любое количество EnemyType, даже нуль</remarks>
    /// Если types равен нулю нужно вернуть пустую коллекцию
    public IEnumerable<EnemyController> GetAllEnemiesByTypes(params EnemyType[] types)
    {
    }

    /// <summary>
    /// Возвращает всех противников определенного типа в определенном радиусе
    /// </summary>
    /// <param name="radius">Радиус, вокруг которого происходит поиск</param>
    /// <param name="unit">Юнит, находящийся в центре окружности поиска</param>
    /// <param name="type">Тип противников</param>
    /// <returns>Коллекция типовых противников</returns>
    public IEnumerable<EnemyController> GetNearestInRaduisByType(float radius, Controller unit, EnemyType type)
    {
    }

    /// <summary>
    /// Возвращает всех противников определенных типов в определенном радиусе
    /// </summary>
    /// <param name="radius">Радиус, вокруг которого происходит поиск</param>
    /// <param name="unit">Юнит, находящийся в центре окружности поиска</param>
    /// <param name="types">Типы противников</param>
    /// <returns>Коллекция типовых противников</returns>
    public IEnumerable<EnemyController> GetNearestInRaduisByTypes(float radius, Controller unit, params EnemyType[] types)
    {
    }

    #endregion

    #region Player Equipment

    /// <summary>
    /// Пытается снарядить предмет на персонажа
    /// </summary>
    /// <param name="equipment">Надеваемый предмет</param>
    /// <returns>Удачно-ли произошло надевание</returns>
    public bool TryToEquipItem(Equipment equipment)
    {
	}

    /// <summary>
    /// Пытается получить предмет с персонажа
    /// </summary>
    /// <param name="type">Тип предмета</param>
    /// <param name="isSuccess">Надет-ли предмет на персонажа</param>
    /// <returns>Запрашиваемый предмет</returns>
    public Equipment TryGetEquipItem(EquipmentItemType type, out bool isSuccess)
    {
	}

    /// <summary>
    /// Снаряжает с заменой предмет
    /// </summary>
    /// <param name="equip">Надеваемый предмет</param>
    /// <param name="isSwitch">Произошла-ли замена снаряжения</param>
    /// <returns>Значение по-умолчанию или снятые предмет</returns>
    public Equipment EquipOrSwitchItem(Equipment equip, out bool isSwitch)
    {
	}

    /// <summary>
    /// Проверяет, надет-ли предмет
    /// </summary>
    /// <param name="id">Уникальный идентификатор предмета</param>
    /// <returns>Надет-ли предмет на персонажа</returns>
    public bool CheckEquipByID(ulong id)
    {
	}

    /// <summary>
    /// Проверяет, надет-ли предмет
    /// </summary>
    /// <param name="name">Название предмета</param>
    /// <returns>Надет-ли предмет на персонажа</returns>
    public bool CheckEquipByName(string name)
    {
    }

    /// <summary>
    /// Пытается получить предмет по идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор предмета</param>
    /// <param name="equip">Значение по-умолчанию или запрашиваемый предмет</param>
    /// <returns>Надет-ли данный предмет на персонажа</returns>
    public bool TryToGetEquipByID(ulong id, out Equipment equip)
    {
    }

    /// <summary>
    /// Пытается получить предмет по названию
    /// </summary>
    /// <param name="id">Название предмета</param>
    /// <param name="equip">Значение по-умолчанию или запрашиваемый предмет</param>
    /// <returns>Надет-ли данный предмет на персонажа</returns>
    public bool TryToGetEquipByName(string name, out Equipment equip)
    {
    }

    /// <summary>
    /// Снятие предмета с персонажа
    /// </summary>
    /// <param name="type">Тип снимаемого предмета</param>
    /// <returns>Снятый предмет</returns>
    public Equipment UnequipItem(EquipmentItemType type)
    {
    }

    /// <summary>
    /// Снятие предмета с персонажа
    /// </summary>
    /// <param name="name">Название снимаемого предмета</param>
    /// <returns>Снятый предмет</returns>
    public Equipment UnequipItem(string name)
    {
    }

    /// <summary>
    /// Снятие предмета с персонажа
    /// </summary>
    /// <param name="id">Идентификатор снимаемого предмета</param>
    /// <returns>Снятый предмет</returns>
    public Equipment UnequipItem(ulong id)
    {
    }

    #endregion

    #region Player inventory

    /// <summary>
    /// Добавляем в сумку персонажу предмет
    /// </summary>
    /// <param name="item">Новый предмет</param>
    /// <returns>Умещается-ли в сумку предмет</returns>
    public bool AddItem(Item item)
    {
    }

    /// <summary>
    /// Добавляем в сумку персонажу предметы
    /// </summary>
    /// <param name="items">Коллекция предметов</param>
    /// <param name="filling">Заполнять-ли сумку до верху</param>
    /// <returns>Умещается-ли в сумку предмет</returns>
    public bool AddItems(IEnumerable<Item> items, bool filling = false)
    {
    }

    /// <summary>
    /// Возвращает количество предметов в инвентаре
    /// </summary>
    /// <returns>Число предметов</returns>
    public int GetCountAllItems()
    {
    }

    /// <summary>
    /// Возвращает вместимость инвентаря
    /// </summary>
    /// <returns>Максимальное количество предметов в сумке</returns>
    public int GetCapacityInventory()
    {
	}

    /// <summary>
    /// Возвращает количество предметов одного типа
    /// </summary>
    /// <param name="id">Идентификатор типа предметов</param>
    /// <returns>Количество предметов</returns>
    public int GetCountItemsByID(ulong id)
    {
	}

    /// <summary>
    /// Возвращает количество предметов одного наименования
    /// </summary>
    /// <param name="name">Название предметов</param>
    /// <param name="isFullCompliance">Считать только те, что имеют название точь-в-точь</param>
    /// <returns>Количество предметов</returns>
    public int GetCountItemsByName(string name, bool isFullCompliance = true)
    {
    }

    /// <summary>
    /// Возвращает количество уникальных предметов
    /// </summary>
    public int GetCountUniqueItems()
    {
	}

    /// <summary>
    /// Возвращает все дубликаты предметов из инвентаря и удаляет их оттуда
    /// </summary>
    /// <returns>Коллекция извлеченных предметов</returns>
    public IEnumerable<Item> GetAndRemoveAllDuplicates()
    {
	}

    /// <summary>
    /// Возвращает все одинаковые предметы
    /// </summary>
    /// <param name="id">Идентификатор запрашиваемых предметов</param>
    /// <returns>Коллекция одинаковых предметов</returns>
    public IEnumerable<Item> GetItemsByID(ulong id)
    {
	}

    /// <summary>
    /// Возвращает все одинаковые предметы
    /// </summary>
    /// <param name="name">Название предметов</param>
    /// <param name="isFullCompliance">Считать только те, что имеют название точь-в-точь</param>
    /// <returns>Коллекция одинаковых предметов</returns>
    public IEnumerable<Item> GetItemsByName(string name, bool isFullCompliance = true)
    {
    }

    /// <summary>
    /// Уничтожает все одинаковые предметы по имени
    /// </summary>
    /// <param name="name">Название предметов</param>
    /// <param name="isFullCompliance">Считать только те, что имеют название точь-в-точь</param>
    public void RemoveAllItemsWithName(string name, bool isFullCompliance = true)
    {
    }

    /// <summary>
    /// Уничтожает все одинаковые предметы по идентификатору
    /// </summary>
    /// <param name="name">Идентификатор предметов</param>
    public void RemoveAllItemsWithID(ulong id)
    {
	}

    /// <summary>
    /// Заменяет предмет на новый
    /// </summary>
    /// <param name="replaceID">Идентификатор заменяемых предметов</param>
    /// <param name="count">Количество заменяемых предметов</param>
    /// <param name="newItem">Новый предмет на замену</param>
    /// <returns>Удачна-ли операция</returns>
    public bool ReplaceItemsWith(ulong replaceID, int count, Item newItem)
    {
    }

    /// <summary>
    /// Заменяет предмет на новый
    /// </summary>
    /// <param name="replaceName">Название заменяемых предметов</param>
    /// <param name="count">Количество заменяемых предметов</param>
    /// <param name="newItem">Новый предмет на замену</param>
    /// <returns>Удачна-ли операция</returns>
    public bool ReplaceItemsWith(string replaceName, int count, Item newItem)
    {
    }

    #endregion
}