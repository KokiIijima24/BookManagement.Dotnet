import React from 'react'
import { Route, Redirect } from 'react-router-dom'

const GuestRoute = ({ component: Component, layout: Layout, ...rest }) => {
  return (
    <Route
      {...rest}
      render={(props) => (
        <Layout>
          <Component {...props} />
        </Layout>
      )}
    />
  )
}

export default GuestRoute
