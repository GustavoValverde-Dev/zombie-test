//Importar as dependências
import React from 'react';
import {BrowserRouter, Switch, Route} from 'react-router-dom';

//Importar as páginas
import Main from './views/main/Main';
import Resources from './views/resource/Resources';

//Criar o componentes com as rotas
function Routes(){
    return(
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Main} />
                <Route path="/resources" component={Resources} />
            </Switch>        
        </BrowserRouter>
    );
};

export default Routes;