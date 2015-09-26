using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    interface ICollections
    {
        /// <summary>
        /// переберите этот мешок на два других мешка,
        /// в один положите испорченные, а в другой - неиспорченные. 
        /// Из самого первого мешка при этом картофелины должны уже удаляться
        /// </summary>
        /// <param name="potatoeBag">входной мешок картошки</param>
        /// <param name="goodPotatoes">мешок с хорошими картофелинами</param>
        /// <param name="badPotatoes">мешок с плохими картофелинами</param>
        /// <returns>количество хороших картофелин</returns>
        int SortPotatoes(
            List<IPotatoe> potatoeBag, 
            out List<IPotatoe> goodPotatoes,
            out List<IPotatoe> badPotatoes);

        /// <summary>
        /// Сделать логику для второй половины задачки про датчики,
        /// а именно: дано сочетание кода датчика, значения и флаг корректности данных.
        /// Для каждого вида датчика (закодированного отдельным кодом), посчитать
        /// среднее значение среди этого вида, только для корректных данных.
        /// </summary>
        /// <param name="inputData">входные данные</param>
        /// <returns>преобразованные данные</returns>
        List<IOutData> ProcessData(
            IReadOnlyList<IInData> inputData);

        /// <summary>
        /// создайте linked list, наполните его данными из input в порядке возрастания.
        /// </summary>
        /// <param name="input">список из чисел</param>
        /// <returns>созданный linked list</returns>
        LinkedList<int> CreateOrderedList(IReadOnlyList<int> input);

        /// <summary>
        /// пример: передали текст из строк
        /// abcd
        /// 45da
        /// naa
        /// nasdfas
        /// в итоговом словаре должно очутиться 3 записи, с ключами a, 4 и n. по первому и второму ключу в списке будет
        /// всего по одному элементу, а по третьему ключу - два элемента.
        /// </summary>
        /// <param name="words">набор строк</param>
        /// <returns>"карта" символов и списков строк из text, которые начинаются с этого символа</returns>
        IReadOnlyDictionary<char, IList<string>> OrganizeByFirstCharacter(IEnumerable<string> text);

        ISimpleNumbers GetSimpleNumbersInstance(int limit);
    }
}
