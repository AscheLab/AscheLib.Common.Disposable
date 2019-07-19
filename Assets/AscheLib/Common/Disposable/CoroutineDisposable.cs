using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AscheLib {
	public class CoroutineDisposable : IDisposable {
		public readonly Coroutine _target;
		public readonly MonoBehaviour _parent;
		public CoroutineDisposable(Coroutine target, MonoBehaviour parent) {
			_target = target;
			_parent = parent;
		}
		#region IDisposable Support
		bool _disposedValue = false;
		protected virtual void Dispose(bool disposing) {
			if(!_disposedValue) {
				if(disposing) {
					_parent.StopCoroutine(_target);
				}
				_disposedValue = true;
			}
		}
		~CoroutineDisposable() {
			Dispose(false);
		}
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}