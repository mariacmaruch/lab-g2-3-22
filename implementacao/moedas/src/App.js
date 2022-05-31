import React, { Component } from 'react';
import { Route, Routes } from 'react-router';
import  Layout  from './components/Layout.jsx';
import Home from './components/Home.jsx';
import './custom.css'
import Aluno from './views/aluno.jsx';
import CadastroAluno from './components/aluno/cadastro-form.jsx';
import Login from './components/aluno/login.jsx';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Routes>
          <Route path='/' element={<Home /> } />
          <Route path='/Aluno' element={<Aluno />} />
          <Route path='/api/Aluno' element={<CadastroAluno />} />
          <Route path='/api/Aluno/login' element={<Login />} />
        </Routes>
      </Layout>
    );
  }

  
}
