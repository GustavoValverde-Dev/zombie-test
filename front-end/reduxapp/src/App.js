import React from 'react';
import './App.css';
import Routes from './routes';
import { Provider } from 'react-redux'
import store from '../src/components/redux/resource/store'
function App() {
  
  return (
    <div className="App">
      <Provider store={store}>
    <div>
        <Routes />
    </div>    
    </Provider>
    </div>
  );
}

export default App;