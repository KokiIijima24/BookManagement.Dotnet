import React from 'react'
import { BrowserRouter, Switch, Route } from 'react-router-dom'
import { Provider } from 'react-redux'
import { PersistGate } from 'redux-persist/integration/react'

import store, { persistor } from './store/'
import PrivateRoute from './components/Router/PrivateRoute'
import GuestRoute from './components/Router/GuestRoute'
import AppRoute from './components/Router/AppRoute'

import Home from './Pages/Home'
import Login from './Pages/Login'
import About from './Pages/About'

import LoginLayout from './Layout/LoginLayout'
import MainLayout from './Layout/MainLayout'
import Chapter3 from './Pages/Chapter3'
import chapter6 from './Pages/Chapter6'
import chapter7 from './Pages/Chapter7'
import chapter8 from './Pages/Chapter8'



function App() {
  return (
    <Provider store={store}>
      <PersistGate loading={null} persistor={persistor}>
        <BrowserRouter>
          <Switch>
            <AppRoute path='/' exact layout={MainLayout} component={Home} />
            <GuestRoute path='/login' layout={LoginLayout} component={Login} />
            <PrivateRoute path='/about' layout={MainLayout} component={About} />
            <GuestRoute path='/chapter3' layout={MainLayout} component={Chapter3} />
            <GuestRoute path='/chapter6' layout={MainLayout} component={chapter6} />
            <GuestRoute path='/chapter7' layout={MainLayout} component={chapter7} />
            <GuestRoute path='/chapter8' layout={MainLayout} component={chapter8} />
          </Switch>
        </BrowserRouter>
      </PersistGate>
    </Provider>
  )
}

export default App
