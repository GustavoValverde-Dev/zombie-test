import { createGlobalStyle } from "styled-components";

import "font-awesome/css/font-awesome.css";

const GlobalStyles = createGlobalStyle`
@import url('https://fonts.googleapis.com/css2?family=JetBrains+Mono&display=swap');

* 
{
  font-family: 'JetBrains Mono', monospace;
  box-sizing: border-box;
  padding: 0;
  margin: 0;
  outline: 0;
}

body, html {
  background: #000000;
  text-rendering: optimizeLegibility !important;
  -webkit-font-smoothing: antialiased !important;
  height: 100%;
  width: 100%;
}
`;
export default GlobalStyles