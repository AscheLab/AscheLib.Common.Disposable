using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AscheLib {
	public class GameObjectDisposable : IDisposable {
		public readonly GameObject _target;

		public GameObjectDisposable(GameObject go) {
			_target = go;
		}
		#region IDisposable Support
		bool _disposedValue = false;
		protected virtual void Dispose(bool disposing) {
			if(!_disposedValue) {
				if(disposing) {
					GameObject.Destroy(_target);
				}
				_disposedValue = true;
			}
		}
		~GameObjectDisposable() {
			Dispose(false);
		}
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}