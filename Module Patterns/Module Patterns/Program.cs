using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Patterns
{
    //26. Патерни GoF.  Шаблон (Template).
    //Патерн проектуванн - спосіб вирішення проблеми що зустрічається при проектуванні програм
    // Патерн це загальний принцип вирішення певної проблеми,
    // який треба підлаштовувати для потреб програми.
    //Патерни відрізняються і за призначенням:
    //Породжуючі патерни - гнучке створення об’єктів без внесення в програму зайвих залежностей.
    //Структурні патерни - різні способи побудови зв’язків між об’єктами.
    //Поведінкові патерни- ефективна комунікація між об’єктами.

    //Шаблонний метод — це поведінковий патерн, який визначає основу алгоритму і
    //перекладає відповідальність за якісь його кроки на підкласи. Патерн дозволяє підкласам
    //перевизначати кроки алгоритму, не змінюючи його загальної структури.



    //26.Дано колекцію повідомлень (дата, відправник, отримувач, текст). Реалізувати
    //клас надсилання відповіді всім відправникам на повідомлення із заданим
    //текстом.Надіслати відповідь у порядку дати надходження, а також за
    //відправниками (Спочатку на всі повідомлення відправника А, потім
    //відправника Б,...).

    // Я використала патерн ітератор тому що він  дозволяє обійти колекцію об'єктів у певному порядку,
    // не розкриваючи її внутрішньої структури.
    // Що дозволить відсортувати повідомлення та обійти колекції повідомлень для
    // надсилання відповідей у тому порядку який треба

    internal class Program
    {

        static void Main()
        {
            var messageCollection = new MessageCollection();

            messageCollection.AddMessage(new Message(new DateTime(2023, 10, 1), "Alice", "Bob", "Hello"));
            messageCollection.AddMessage(new Message(new DateTime(2023, 10, 2), "Bob", "Alice", "Hi, how are you?"));
            messageCollection.AddMessage(new Message(new DateTime(2023, 10, 3), "Alice", "Charlie", "Meeting at 5"));
            messageCollection.AddMessage(new Message(new DateTime(2023, 10, 1), "Charlie", "Alice", "Got it, thanks!"));
            messageCollection.AddMessage(new Message(new DateTime(2023, 10, 4), "Charlie", "Alice", "Hi Alice! Are you available?"));

            var replySender = new ReplySender(messageCollection);

            replySender.SendReplyToAll("Hi", "Hello! How can I help you?");
        }
    }
    
}
