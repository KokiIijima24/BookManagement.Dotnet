import React, { useState, useEffect } from 'react'
import { useSelector } from 'react-redux'
import { baseRepository } from '../api/auth'
import { isAuthSelector } from '../store/auth'

import EditUserModal from '../components/Modal/EditUserModal'

const Home = () => {
  //const user_info = useSelector((state) => state.user)
  const isAuth = useSelector(isAuthSelector)
  const [users, setUsers] = useState([])

  if (!isAuth) {
    return <div>ログインしてください。</div>
  }

  const deleteGivook = (id) => {
    console.log('cliecked', id)
  }

  useEffect(() => {
    baseRepository.get('api/user/list').then((response) => {
      console.log('response data:', response)
      setUsers(response.data)
    })
  }, [])

  return (
    <div>
      <h1>Home</h1>
      <h3>ユーザーリスト</h3>
      <table className='table-auto'>
        <thead>
          <tr>
            <th className='px-4 py-2'>address</th>
            <th className='px-4 py-2'>user name</th>
            <th className='px-4 py-2'></th>
          </tr>
        </thead>
        <tbody>
          {users.map((user, index) => {
            return (
              <tr key={index}>
                <td className='border px-4 py-2'>{user.displayName}</td>
                <td className='border px-4 py-2'>{user.userName}</td>
                <td>
                  <EditUserModal />
                  <button
                    className='bg-red-500 text-white active:bg-red-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150'
                    type='button'
                    onClick={() => deleteGivook()}
                  >
                    削除
                  </button>
                </td>
              </tr>
            )
          })}
        </tbody>
      </table>
    </div>
  )
}

export default Home
