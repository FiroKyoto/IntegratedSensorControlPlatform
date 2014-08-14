namespace Joystick
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.DirectX.DirectInput;
    using System.Windows.Forms;

    /// <summary>
    /// Steering Wheel control using DirectX.DirectInput
    /// http://nanoappli.com/blog/archives/4772
    /// </summary>
    public class G27
    {
        #region fields

        public Device joystick;
        private DeviceList devList;

        #endregion

        #region constructor

        public G27() 
        {
            this.joystick = null;
            this.devList = null;
        }
        
        #endregion

        #region methods

        /// <summary>
        /// Initialize device control
        /// </summary>
        /// <param name="_parent"></param>
        public void Start(System.Windows.Forms.Control _parent)
        {
            // ゲームコントローラのデバイス一覧を取得
            this.devList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);

            // 全てのコントローラを列挙
            foreach (DeviceInstance dev in devList)
            {
                this.joystick = new Device(dev.InstanceGuid);
                this.joystick.SetCooperativeLevel(_parent, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);

                // 最初に見つかったジョイスティックを操作対象とする
                break;
            }


            this.joystick.SetDataFormat(DeviceDataFormat.Joystick);

            // デバイスに対するアクセス権をとる
            this.joystick.Acquire();
        }

        /// <summary>
        /// Received control data from G27
        /// </summary>
        /// <returns></returns>
        public StringBuilder Controller()
        {
            JoystickState state;
            StringBuilder buffer = new StringBuilder();

            if (this.joystick != null)
            {
                // コントローラの状態をポーリングで取得
                this.joystick.Poll();
                state = this.joystick.CurrentJoystickState;

                // ボタンの状態を出力
                buffer.Clear();
                int count = 0;
                foreach (byte button in state.GetButtons())
                {
                    if (count++ >= this.joystick.Caps.NumberButtons)
                    {
                        // ボタンの数分だけ状態を取得したら終了
                        break;
                    }

                    // add input data
                    //buffer.Append(count.ToString() + ": " + button.ToString() + ", ");
                    buffer.Append(button.ToString() + " ");
                }

                // left(0), center(32768), right(65535)
                //buffer.Append("Wheel: " + state.X.ToString());
                buffer.Append(state.X.ToString());
            }
            else
            {
                // デバイス未決定時は何もしない
            }

            return buffer;
        }

        #endregion
    }
}
