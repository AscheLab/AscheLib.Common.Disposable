using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AscheLib {
	public class DisposableBundle : IDisposable {
		readonly List<IDisposable> _list = new List<IDisposable>();
		public void Add(params IDisposable[] disposables) {
			foreach(var d in disposables) {
				_list.Add(d);
			}
		}
		#region IDisposable Support
		bool _disposedValue = false;
		protected virtual void Dispose(bool disposing) {
			if(!_disposedValue) {
				if(disposing) {
					_list.ForEach(d => d.Dispose());
				}
				_disposedValue = true;
			}
		}
		~DisposableBundle() {
			Dispose(false);
		}
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}