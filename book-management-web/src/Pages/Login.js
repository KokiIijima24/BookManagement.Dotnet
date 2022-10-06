import React, { useState } from 'react'
import { useHistory } from 'react-router-dom'
import { useDispatch } from 'react-redux'
import { login } from '../store/auth'

import Spinner from '../components/Utils/Spinner'

const Login = () => {
  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')
  const [isLoading, setIsLoading] = useState(false)

  const history = useHistory()
  const dispatch = useDispatch()

  const submit = async () => {
    setIsLoading(true)
    history.push('/about')
    await dispatch(login(username, password))
    setIsLoading(false)
  }

  return (
    <div className='bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4 flex flex-col'>
      <form onSubmit={submit}>
        <div className='mb-4'>
          <label
            className='block text-grey-darker text-sm font-bold mb-2'
            htmlFor='username'
          >
            Username
          </label>
          <input
            className='shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker'
            id='username'
            type='text'
            placeholder='Username'
            type='text'
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div className='mb-6'>
          <label
            className='block text-grey-darker text-sm font-bold mb-2'
            htmlFor='password'
          >
            Password
          </label>
          <input
            className='shadow appearance-none border border-red rounded w-full py-2 px-3 text-grey-darker mb-3'
            id='password'
            type='password'
            placeholder='******************'
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <p className='text-red text-xs italic'>Please choose a password.</p>
        </div>
        <div className='flex items-center justify-between'>
          <button
            className={'bg-blue-600 hover:bg-blue-dark text-white font-bold py-2 px-4 rounded'
          + (isLoading ? ' cursor-not-allowed opacity-50' : '')}
            type='submit'
          >
            Sign In
          </button>
          <a
            className='inline-block align-baseline font-bold text-sm text-blue hover:text-blue-darker hidden'
            href='#'
          >
            Forgot Password?
          </a>
        </div>
      </form>
    </div>
  )
}

export default Login
