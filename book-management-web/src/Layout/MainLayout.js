import React from 'react'
import HeaderMenu from '../components/Common/HeaderMenu'

const MainLayout = props => {

  return (
    <div>
      <HeaderMenu />
      {props.children}
    </div>
  )
}
export default MainLayout
