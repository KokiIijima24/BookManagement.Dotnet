import React from 'react'
import { Route, Redirect } from 'react-router-dom'
import { useSelector } from 'react-redux'
import { isAuthSelector } from '../../store/auth'

const PrivateRoute = ({ component: Component, layout: Layout, ...rest }) => {
  const isAuth = useSelector(isAuthSelector)
  console.log('rest;', rest)

  return isAuth ? (
    <Route
      {...rest}
      render={(props) => (
        <Layout>
          <Component {...props} />
        </Layout>
      )}
    />
  ) : (
    <Redirect to='/login' />
  )
}

export default PrivateRoute
