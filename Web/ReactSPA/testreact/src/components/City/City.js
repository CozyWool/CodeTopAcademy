import cityStyles from './City.module.css';
import React from "react";

function importAll(req) {
    return req.keys().map((item) => req(item));
}

const imgs = importAll(require.context('/src/img', false, /\.jpg$/));


const City = ({count}) => {
    const sliderRef = React.useRef(null);
    const scroll  = () => {
        if(sliderRef.current){
            sliderRef.current.scrollBy({left: 300});
        }
    }
    return (
        <div className={cityStyles.mainContainer}>
            <h1 className={cityStyles.cityName}><a href="https://www.tyumen-city.ru" className={cityStyles.link}>Тюмень</a></h1>
            <p className={cityStyles.cityCountry}>Страна: Россия</p>
            <p className={cityStyles.cityFounded}>Год основания: 1586</p>

            <div className={cityStyles.slider}>
                <div className={cityStyles.cityImages} ref={sliderRef}>
                    {imgs.slice(0, count).map((img, index) => (
                        <img key={index} src={img} alt={`${index}`} />
                    ))}
                </div>

                <button className={cityStyles.arrow} onClick={scroll}>{'<'}</button>
            </div>
        </div>
    );
};

export default City;