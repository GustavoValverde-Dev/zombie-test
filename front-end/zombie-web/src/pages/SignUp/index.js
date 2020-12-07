import React, { Component } from "react";
import { Link, withRouter } from "react-router-dom";
import api from "../../services/api";
import Logo from "../../assets/zombie-logo.jpg";
import md5 from "md5";

import { Form, Container } from "./styles";

class SignUp extends Component {
  state = {
    name: "",
    cpf: "",
    password: "",
    error: ""
  };

  handleSignUp = async e => {
    e.preventDefault();
    const { name, cpf, password } = this.state;
    if (!name || !cpf || !password) {
      this.setState({ error: "Preencha todos os dados para se cadastrar" });
    } else {
      try {
        let md5Hash = md5(password);

        let obj = {
            Name: name,
            CPF: cpf,
            Password: md5Hash
        }

        await api.post("/users/add", obj);
        alert(this.response.data);
        this.props.history.push("/");
      } catch (err) {
        this.setState({ error: err.response.data });
      }
    }
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

export default withRouter(SignUp);