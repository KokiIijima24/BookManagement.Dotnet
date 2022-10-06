import React, { useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'

import { Link } from 'react-router-dom'
import { logout, isAuthSelector } from '../../store/auth'

const HeaderMenu = () => {
  const isAuth = useSelector(isAuthSelector)
  const dispatch = useDispatch()
  const user = useSelector((state) => state.auth.user)

  const [barState, setBarState] = useState(false)

  const signout = async () => {
    await dispatch(logout())
  }

  if (isAuth) {
    return (
      <nav className='flex items-center justify-between flex-wrap bg-green-400 p-6'>
        <div className='flex items-center flex-no-shrink text-white mr-6'>
          <svg
            xmlns='http://www.w3.org/2000/svg'
            className='h-5 w-5 mr-2'
            viewBox='0 0 20 20'
            fill='currentColor'
          >
            <path d='M9 4.804A7.968 7.968 0 005.5 4c-1.255 0-2.443.29-3.5.804v10A7.969 7.969 0 015.5 14c1.669 0 3.218.51 4.5 1.385A7.962 7.962 0 0114.5 14c1.255 0 2.443.29 3.5.804v-10A7.968 7.968 0 0014.5 4c-1.255 0-2.443.29-3.5.804V12a1 1 0 11-2 0V4.804z' />
          </svg>
          <span className='font-semibold text-xl tracking-tight'>React Auth 
          Sample</span>
        </div>
        <div className='block lg:hidden'>
          <button
            className='flex items-center px-3 py-2 border rounded text-teal-lighter border-teal-light hover:text-white hover:border-white'
            onClick={() => setBarState(!barState)}
          >
            <svg
              className='h-3 w-3'
              viewBox='0 0 20 20'
              xmlns='http://www.w3.org/2000/svg'
            >
              <title>Menu</title>
              <path d='M0 3h20v2H0V3zm0 6h20v2H0V9zm0 6h20v2H0v-2z' />
            </svg>
          </button>
        </div>
        <div
          className={
            'w-full block flex-grow lg:flex lg:items-center lg:w-auto' +
            (barState ? '' : ' hidden')
          }
        >
          <div className='text-sm lg:flex-grow'>
            <Link
              to='/'
              className='block mt-4 lg:inline-block lg:mt-0 text-teal-200 hover:text-white mr-4'
            >
              Home
            </Link>

            <Link
              to='/about'
              className='block mt-4 lg:inline-block lg:mt-0 text-teal-200 hover:text-white mr-4'
            >
              About
            </Link>

            <Link
              to='/chapter3'
              className='block mt-4 lg:inline-block lg:mt-0 text-teal-200 hover:text-white mr-4'
            >
              chapter3
            </Link>
            <Link
              to='/chapter6'
              className='block mt-4 lg:inline-block lg:mt-0 text-teal-200 hover:text-white mr-4'
            >
              chapter6
            </Link>
            <Link
              to='/chapter7'
              className='block mt-4 lg:inline-block lg:mt-0 text-teal-200 hover:text-white mr-4'
            >
              chapter7
            </Link>
            <Link
              to='/chapter8'
              className='block mt-4 lg:inline-block lg:mt-0 text-teal-200 hover:text-white mr-4'
            >
              chapter8
            </Link>
          </div>
          <div>
            <button
              onClick={signout}
              className='inline-block text-sm px-4 py-2 leading-none border rounded text-white border-white hover:border-transparent hover:text-teal hover:bg-white mt-4 lg:mt-0'
            >
              Logout
            </button>
          </div>
        </div>
      </nav>
    )
  } else {
    return (
      <nav className='flex items-center justify-between flex-wrap bg-green-400 p-6'>
        <div className='flex items-center flex-no-shrink text-white mr-6'>
          <svg
            xmlns='http://www.w3.org/2000/svg'
            className='h-5 w-5 mr-2'
            viewBox='0 0 20 20'
            fill='currentColor'
          >
            <path d='M9 4.804A7.968 7.968 0 005.5 4c-1.255 0-2.443.29-3.5.804v10A7.969 7.969 0 015.5 14c1.669 0 3.218.51 4.5 1.385A7.962 7.962 0 0114.5 14c1.255 0 2.443.29 3.5.804v-10A7.968 7.968 0 0014.5 4c-1.255 0-2.443.29-3.5.804V12a1 1 0 11-2 0V4.804z' />
          </svg>
          <span className='font-semibold text-xl tracking-tight'>React Auth Sample</span>
        </div>
        <div className='block lg:hidden'>
          <button
            className='flex items-center px-3 py-2 border rounded text-teal-lighter border-teal-light hover:text-white hover:border-white'
            onClick={() => setBarState(!barState)}
          >
            <svg
              className='h-3 w-3'
              viewBox='0 0 20 20'
              xmlns='http://www.w3.org/2000/svg'
            >
              <title>Menu</title>
              <path d='M0 3h20v2H0V3zm0 6h20v2H0V9zm0 6h20v2H0v-2z' />
            </svg>
          </button>
        </div>
        <div
          className={
            'w-full block flex-grow lg:flex lg:items-center lg:w-auto' +
            (barState ? '' : ' hidden')
          }
        >
          <div className='text-sm lg:flex-grow'>
            <Link
              to='/'
              className='block mt-4 lg:inline-block lg:mt-0 text-teal-200 hover:text-white mr-4'
            >
              Home
            </Link>
          </div>
          <div>
            <Link
              to='/login'
              className='inline-block text-sm px-4 py-2 leading-none border rounded text-white border-white hover:border-transparent hover:text-teal hover:bg-white mt-4 lg:mt-0'
            >
              Login
            </Link>
          </div>
        </div>
      </nav>
    )
  }
}

export default HeaderMenu
