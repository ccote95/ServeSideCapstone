import React from 'react';
import { Toast, ToastBody, ToastHeader } from 'reactstrap';

const CustomToast = ({ isOpen, toggle, message }) => {
    return (
        <div className="p-3 my-2 rounded" style={{ position: 'fixed', top: '20px', right: '20px', zIndex: 1050 }}>
            <Toast isOpen={isOpen}>
                <ToastHeader toggle={toggle}>
                    Notification
                </ToastHeader>
                <ToastBody className=" bg-success" style={{color: "white"}}>
                    {message}
                </ToastBody>
            </Toast>
        </div>
    );
};

export default CustomToast;
