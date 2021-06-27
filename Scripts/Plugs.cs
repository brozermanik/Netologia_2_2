using UnityEngine;

/// <summary>
/// Заглушки, логика в них, для данного ДЗ не требуется
/// </summary>
namespace Netologia_2_2
{
    /// <summary>
    /// Родительский компонент для управление персонажами
    /// </summary>
    public class Controller : MonoBehaviour { }

    /// <summary>
    /// Наследник, определяющий поведение неиграбельных персонажей-противников
    /// </summary>
    public class EnemyController : Controller 
    {
        public EnemyType Type { get; private set; }
    }

    /// <summary>
    /// Наследник, определяющий поведение игрока
    /// </summary>
    public class PlayerController : Controller { }

    /// <summary>
    /// Внутренее описание предмета, его картинка, его моделька, эффекты и прочее
    /// </summary>
    public class ItemProperty { }
}