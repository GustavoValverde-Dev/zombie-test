import React, { Component } from "react";
import { Link, withRouter } from "react-router-dom";

import Logo from "../../assets/zombie-logo.jpg";
import api from "../../services/api";
import { login } from "../../services/auth";
import md5 from "md5";

import { Form, Container } from "./styles";

class SignIn extends Component {
  state = {
    cpf: "",
    password: "",
    error: ""
  };

  handleSignIn = async e => {
    e.preventDefault();
    const { cpf, password } = this.state;
    if (!cpf || !password) {
      this.setState({ error: "Preencha CPF e senha para continuar!" });
    } else {
      try {

        let md5Hash = md5(password);

        let obj = {
            CPF: cpf,
            Senha: md5Hash
        }

        const response = await api.post("/auth/login", obj);
        login(response.data.token);
        this.props.history.push("/app");
      } catch (err) {
        this.setState({
          error:
            err.response.data
        });
      }
    }
  };

  render() {
    return (
      <Container>
        <Form onSubmit={this.handleSignIn}>
          <img style={{width: 15 + 'rem'}} src={Logo} alt="Zombie logo" />
          {this.state.error && <p>{this.state.error}</p>}
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
          <button type="submit">Entrar</button>
          <hr />
          <Link to="/signup">Criar conta</Link>
        </Form>
      </Container>
    );
  }
}

export default withRouter(SignIn);