import React, { Component } from "react";
import { Link, withRouter } from "react-router-dom";
import DataTable from "react-data-table-component";
import api from "../../services/api";
import { getToken } from "../../services/auth";
import { Button } from "styled-button-component";
import { Navbar, NavbarLink } from "styled-navbar-component";
import { Nav } from "styled-nav-component";

import { Container } from "./styles";

class MainPage extends Component {
  state = {
    resourceData: []
  };
   columns = [
    {
        name: "Tipo",
        selector: "resourceTypeName"
    },
    {
        name: "Descrição",
        selector: "description"
    },
    {
        name: "Status",
        selector: "status"
    },
    {
        name: "Quantidade",
        selector: "quantity"
    },
    {
        name: "Quantidade Mínima",
        selector: "minQuantity"
    },
    {
        name: "Quantidade Máxima",
        selector: "maxQuantity"
    },
    {
        name: "Observação",
        selector: "observation"
    },
    {
        name: "Inserido por",
        selector: "createdBy"
    },
    {
        name: "Data de criação",
        selector: "creationDate"
    }
]
  

  componentDidMount(){
    


    var token = getToken(); 
    console.log(token);
    api.get( '/resources/getall', { headers: { Token: token } })
     .then(response => {
         console.log(response.data);
        this.setState({resourceData: response.data})
      })
     .catch((error) => {
         console.log('error ' + error);
      });
  }
  

  render() {
    return (
        
      <Container>
            <Navbar expandSm dark>
                <Nav start>
                    <Link to='/app'>
                    <NavbarLink dark brand active >Recursos</NavbarLink>
                    </Link>
                    <Link to='/app'>
                    <NavbarLink dark brand >Usuários</NavbarLink>
                    </Link>
                    <Link to='/app'>
                    <NavbarLink dark brand >Grupos</NavbarLink>
                    </Link>
                    <Link to='/app'>
                    <NavbarLink dark brand >Funções</NavbarLink>
                    </Link>
                    <Nav end>
                    <Button
                        dark
                        outline
                        toggleCollapse
                        expandSm
                    >
                        <span>&#9776;</span>
                    </Button>
                    </Nav>
                </Nav>
            </Navbar>
        <div style={{marginTop: 8 + 'rem'}}> 
        <DataTable
            title="Recursos"
            columns={this.columns}
            data={this.state.resourceData}
            theme="dark"
        />
        </div>
      </Container>
    );
  }
}

export default withRouter(MainPage);