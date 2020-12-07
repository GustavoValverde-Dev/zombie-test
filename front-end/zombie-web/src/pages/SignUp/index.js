import React, { Component } from "react";
import { Link } from "react-router-dom";

import Logo from "../../assets/zombie-logo.jpg";

import { Form, Container } from "./styles";

class SignUp extends Component {
  state = {
    name: "",
    cpf: "",
    password: "",
    error: ""
  };

  handleSignUp = e => {
    e.preventDefault();
    alert("Eu vou te registrar");
  };

  render() {
    return (
      <Container>
        <Form onSubmit={this.handleSignUp}>
          <img style={{width: 15 + 'rem'}} src={Logo} alt="Zombie logo" />
          {this.state.error && <p>{this.state.error}</p>}
          <input
            type="text"
            placeholder="Nome de usuário"
            onChange={e => this.setState({ name: e.target.value })}
          />
          <input
            type="text"
            maxLength="11"
            placeholder="CPF"
            onChange={e => this.setState({ cpf: e.target.value })}
          />
          <input
            type="password"
            placeholder="Senha"
            onChange={e => this.setState({ password: e.target.value })}
          />
          <button type="submit">Cadastrar</button>
          <hr />
          <Link to="/">Fazer login</Link>
        </Form>
      </Container>
    );
  }
}

export default SignUp;