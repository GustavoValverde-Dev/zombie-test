import React, { Component } from "react";
import { Link, withRouter } from "react-router-dom";

import Logo from "../../assets/zombie-logo.jpg";
import api from "../../services/api";
import { getToken } from "../../services/auth";

import { Form, Container } from "./styles";

class MainPage extends Component {
  state = {
    
  };

  componentDidMount(){
    var token = getToken(); 
    console.log(token);
    api.get( '/resources/getall', { headers: { Token: token } })
     .then(response => {
         // If request is good...
         console.log(response.data);
      })
     .catch((error) => {
         console.log('error ' + error);
      });
  }

  render() {
    return (
      <Container>
        <Form>
          <img style={{width: 15 + 'rem'}} src={Logo} alt="Zombie logo" />
          {this.state.error && <p>{this.state.error}</p>}
          <input
            type="text"
            maxLength="11"
            placeholder="CPF"
          />
          <input
            type="password"
            placeholder="Senha"
          />
          <button type="submit">Entrar</button>
          <hr />
          <Link to="/signup">Criar conta</Link>
        </Form>
      </Container>
    );
  }
}

export default withRouter(MainPage);