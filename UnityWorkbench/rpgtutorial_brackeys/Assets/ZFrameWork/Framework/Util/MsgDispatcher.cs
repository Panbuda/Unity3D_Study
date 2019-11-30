using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace ZFramework
{
	public class MsgDispatcher
	{
		//简易消息机制
		static Dictionary<string, Action<object>> m_MsgDictionary = new Dictionary<string, Action<object>>();//m表示不被外部访问

		public static void Register(string msgName, Action<object> action)
		{
			if (!m_MsgDictionary.ContainsKey(msgName))//实现同一个消息下多个回调函数重复注册
				m_MsgDictionary.Add(msgName, _ => { });
			m_MsgDictionary[msgName] += action;
		}

		public static void UnRegisterAll(string msgName)//注销一个消息下的所有回调
		{
			m_MsgDictionary.Remove(msgName);
		}

		public static void UnRegister(string msgName, Action<object> action)//注销一个消息下的某个回调
		{
			m_MsgDictionary[msgName] -= action;
		}

		public static void SendMsg(string msgName, object data)
		{
			if (m_MsgDictionary.ContainsKey(msgName))
				m_MsgDictionary[msgName](data);
		}
	}
}

