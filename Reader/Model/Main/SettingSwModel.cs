namespace Reader.Model.Main
{
    public interface ISettingSwModel
    {
        object[] GetActivatorItems();
        object[] GetRssi1Items();
        object[] GetRssi2Items();
        object[] GetTagFilterItems();
    }

    public class SettingSwModel : ISettingSwModel
    {
        public object[] GetActivatorItems()
        {
            List<object> list = new() { "Off" };

            for (int i = 0; i <= 9; i++) list.Add(i);

            return list.ToArray<object>();
        }

        public object[] GetTagFilterItems()
        {
            List<object> list = new() { "Off" };

            for (int i = 1; i < 10; i++) list.Add(i);
            for (int i = 2; i <= 12; i++) list.Add(i * 5);
            for (int i = 7; i <= 12; i++) list.Add(i * 10);
            for (int i = 5; i <= 10; i++) list.Add(i * 30);
            for (int i = 6; i <= 10; i++) list.Add(i * 60);

            return list.ToArray<object>();
        }

        public object[] GetRssi1Items()
        {
            List<object> list = new() { "Off" };

            for (int i = 1; i <= 31; i++) list.Add(i);

            return list.ToArray<object>();
        }

        public object[] GetRssi2Items()
        {
            List<object> list = new() { "Off" };

            for (int i = 1; i <= 25; i++) list.Add(i * 10);

            return list.ToArray<object>();
        }
    }
}
