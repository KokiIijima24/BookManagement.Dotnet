import React, { useState, useEffect } from 'react'
import { useSelector } from 'react-redux'
import { baseRepository } from '../../api/auth'
import InputField from '../Utils/InputForm'

function EditUserModal() {
  const [showEditModal, setShowEditModal] = useState(false)

  const [inputValue, setInputValue] = useState({ content: '' })
  const { content } = inputValue

  const [isLoading, setIsLoading] = useState(false)
  const user = useSelector((state) => state.auth.user)

  useEffect(() => {
    setInputValue((prev) => ({
      ...prev,
      userId: user.id,
      DisplayName: user.displayName,
    }))
  }, [user])

  const handleChange = (e) => {
    console.log('target element:', e.target)
    const { name, value } = e.target
    setInputValue((prev) => ({
      ...prev,
      [name]: value,
    }))
    console.log(inputValue)
  }

  const submit = async () => {
    setIsLoading(true)
    baseRepository.put('api/comment/post', inputValue).then((response) => {
      console.log('create comment', response)
      setIsLoading(false)
      setShowEditModal(false)
    })
  }

  return (
    <div>
      <button
        className='bg-green-500 text-white active:bg-green-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150 disabled:opacity-50'
        type='button'
        onClick={() => setShowEditModal(true)}
      >
        編集
      </button>
      {showEditModal ? (
        <>
          <div className='justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none'>
            <div className='relative w-auto my-6 mx-auto max-w-3xl'>
              {/*detail*/}
              <div className='border-0 rounded-lg shadow-lg relative flex flex-col w-full bg-white outline-none focus:outline-none'>
                {/*header*/}
                <div className='flex items-start justify-between p-5 border-b border-solid border-blueGray-200 rounded-t'>
                  <h3 className='text-3xl font-semibold'>コメントの作成</h3>
                  <button
                    className='p-1 ml-auto bg-transparent border-0 text-black float-right text-3xl leading-none font-semibold outline-none focus:outline-none'
                    onClick={() => setShowEditModal(false)}
                  >
                    <span className='bg-transparent text-black h-6 w-6 text-2xl block outline-none focus:outline-none'>
                      ×
                    </span>
                  </button>
                </div>
                {/*body*/}
                <div className='relative p-6 flex-auto'>
                  <p className='my-4 text-blueGray-500 text-lg leading-relaxed'>
                    コメントを残してください
                  </p>
                  <div className='mb-6'>
                    <InputField
                      value={content}
                      type='content'
                      placeholder='コメント'
                      name='content'
                      label='タイトル'
                      onChange={handleChange}
                    />
                  </div>
                </div>
                {/*footer*/}
                <div className='flex items-center justify-end p-6 border-t border-solid border-blueGray-200 rounded-b'>
                  <button
                    className='text-red-500 background-transparent font-bold uppercase px-6 py-2 text-sm outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150'
                    type='button'
                    onClick={() => setShowEditModal(false)}
                  >
                    Close
                  </button>
                  <button
                    className='bg-blue-500 text-white active:bg-blue-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150'
                    type='button'
                    onClick={() => submit()}
                  >
                    作成
                  </button>
                </div>
              </div>
            </div>
          </div>
          <div className='opacity-25 fixed inset-0 z-40 bg-black'></div>
        </>
      ) : null}
    </div>
  )
}

export default EditUserModal
