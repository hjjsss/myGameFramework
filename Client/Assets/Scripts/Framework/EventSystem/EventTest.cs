/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/01/07 22:19:02
** desc:  �¼�ϵͳ����
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class EventTest : MonoBehaviour
    {
        void Start()
        {
            EventMgr<EventTestEnum>.AddEvent(EventTestEnum.TestEnum, OnEvent1);
            EventMgr<EventTestEnum>.AddEvent<int>(EventTestEnum.TestEnum, OnEvent2);
        }

        void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 200, 50), "Event1 Fire"))
            {
                EventMgr<EventTestEnum>.FireEvent(EventTestEnum.TestEnum);
            }
            if (GUI.Button(new Rect(10, 70, 200, 50), "Event1 Remove"))
            {
                EventMgr<EventTestEnum>.RemoveEvent(EventTestEnum.TestEnum, OnEvent1);
            }

            if (GUI.Button(new Rect(10, 130, 200, 50), "Event2 Fire"))
            {
                EventMgr<EventTestEnum>.FireEvent<int>(EventTestEnum.TestEnum, 12345);
            }
            if (GUI.Button(new Rect(10, 200, 200, 50), "Event2 Remove"))
            {
                EventMgr<EventTestEnum>.RemoveEvent<int>(EventTestEnum.TestEnum, OnEvent2);
            }
        }

        private void OnEvent1()
        {
            Debug.Log("=====>OnEvent1!");
        }

        private void OnEvent2(int value)
        {
            Debug.Log("=====>OnEvent2 " + value.ToString() + " !");
        }
    }

    public enum EventTestEnum
    {
        TestEnum,
    }
}