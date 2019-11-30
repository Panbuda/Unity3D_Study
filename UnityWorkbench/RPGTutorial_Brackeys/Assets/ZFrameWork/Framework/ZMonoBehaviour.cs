using UnityEngine;
using System.Collections.Generic;
using System;

namespace ZFramework
{
	public abstract partial class ZMonoBehaviour : MonoBehaviour
	{
		//定时
		public void Delay(float second, System.Action onFinished)
		{
			StartCoroutine(DelayCoroutine(second, onFinished));
		}
		private System.Collections.IEnumerator DelayCoroutine(float second, System.Action onFinished)
		{
			yield return new WaitForSeconds(second);
			onFinished();
		}

		//消息机制
		//为了防止消息注册后没有注销，把这个机制集成到MonoBehaviour中，统一注销
		List<MsgRecord> registRecorder = new List<MsgRecord>();

		class MsgRecord
		{	//通过维护一个对象池来提高性能
			static Stack<MsgRecord> m_MsgRecords = new Stack<MsgRecord>();

			private MsgRecord() { }//通过private关闭外部构造入口

			public static MsgRecord Allocate(string msgName, Action<object> ac)
			{
				MsgRecord newRecord = m_MsgRecords.Count > 0 ? m_MsgRecords.Pop() : new MsgRecord();
				newRecord.name = msgName;
				newRecord.action = ac;
				return newRecord;
			}

			public void Recycle()
			{
				name = null;
				action = null;
				m_MsgRecords.Push(this);
			}

			public string name;
			public Action<object> action;
		}

		public void RegistMsg(string msgName, Action<object> action)
		{
			registRecorder.Add(MsgRecord.Allocate(msgName, action));
			MsgDispatcher.Register(msgName, action);
		}
		public void SendMsg(string msgName, object data)
		{
			MsgDispatcher.SendMsg(msgName, data);
		}
		public void UnregistMsgAll(string msgName)
		{
			var selectedMsgs = registRecorder.FindAll(records => records.name == msgName);
			selectedMsgs.ForEach(records =>
			{
				MsgDispatcher.UnRegister(msgName, records.action);
				registRecorder.Remove(records);
				records.Recycle();
			});

			selectedMsgs.Clear();
		}
		public void UnregistMsg(string msgName, System.Action<object> action)
		{
			var selectedMsgs = registRecorder.FindAll(records => records.name == msgName && records.action == action);
			selectedMsgs.ForEach(records =>
			{
				MsgDispatcher.UnRegister(msgName, records.action);
				registRecorder.Remove(records);
				records.Recycle();
			});

			selectedMsgs.Clear();
		}
		private void OnDestroy()
		{
			OnBeforeDestroy();

			foreach (var msgRecord in registRecorder)
			{
				MsgDispatcher.UnRegister(msgRecord.name, msgRecord.action);
				msgRecord.Recycle();
			}
			registRecorder.Clear();
		}

		protected void OnBeforeDestroy() { }//用于替换原先的OnDestroy
	}
}

