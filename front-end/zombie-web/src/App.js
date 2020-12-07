import React, { Fragment } from "react";
import "./styles/global";
import Routes from "./routes";
import GlobalStyle from './styles/global';

function App() {
  return (
    <Fragment>
      <GlobalStyle />
      <Routes />
    </Fragment>
  );
}
 
export default App;