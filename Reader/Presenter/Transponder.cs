using Reader.View;

namespace Reader.Presenter
{
    public interface ITransponder
    {
        bool Add(RFID.StructTransponder structTransponder, int activator, int tagFilter, int rssi1, int rssi2);
        void Clear();
    }

    public class Transponder : ITransponder
    {
        #region variables
        private readonly IMainForm _mainForm;

        private readonly List<RFID.StructTransponder> listStructTransponder = new();
        #endregion

        public Transponder(IMainForm mainForm)
        {
            _mainForm = mainForm;
        }

        public bool Add(RFID.StructTransponder structTransponder, int activator, int tagFilter, int rssi1, int rssi2)
        {
            try
            {
                if (activator > -1 && activator != structTransponder.Activator)
                {
                    structTransponder.Activator = activator;
                }

                if (rssi1 > -1 && rssi1 > structTransponder.Rssi1)
                {
                    return false;
                }

                if (rssi2 > -1 && rssi2 > structTransponder.Rssi2)
                {
                    return false;
                }

                var index = listStructTransponder.FindIndex(s => s.Activator == structTransponder.Activator && s.Number == structTransponder.Number);

                if (index > -1)
                {
                    if (tagFilter > -1 && tagFilter > structTransponder.Value - listStructTransponder[index].Value)
                    {
                        return false;
                    }

                    listStructTransponder[index] = structTransponder;

                    _mainForm.LogTransponder_Update(index, structTransponder.Activator, structTransponder.Number, structTransponder.Value, structTransponder.Rssi1, structTransponder.Rssi2, structTransponder.Battery);

                    return true;
                }
                else
                {
                    listStructTransponder.Add(structTransponder);

                    _mainForm.LogTransponder_Add(structTransponder.Activator, structTransponder.Number, structTransponder.Value, structTransponder.Rssi1, structTransponder.Rssi2, structTransponder.Battery);

                    return true;
                }
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, true);
            }

            return false;
        }

        public void Clear()
        {
            try
            {
                listStructTransponder.Clear();

                _mainForm.LogTransponder_Clear();
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, true);
            }
        }
    }
}
