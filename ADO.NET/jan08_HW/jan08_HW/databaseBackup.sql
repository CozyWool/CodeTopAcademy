toc.dat                                                                                             0000600 0004000 0002000 00000006766 14551760635 0014472 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP                        |            jan08_HW    16.1    16.1     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false         �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false         �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false         �           1262    20598    jan08_HW    DATABASE     ~   CREATE DATABASE "jan08_HW" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "jan08_HW";
                postgres    false                     2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                pg_database_owner    false         �           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                   pg_database_owner    false    4         I           1247    20618    type_of_food    TYPE     J   CREATE TYPE public.type_of_food AS ENUM (
    'Vegetable',
    'Fruit'
);
    DROP TYPE public.type_of_food;
       public          postgres    false    4         �            1259    20624    vegetables_and_fruits    TABLE     �   CREATE TABLE public.vegetables_and_fruits (
    id integer NOT NULL,
    name character varying(55) NOT NULL,
    type public.type_of_food NOT NULL,
    color character varying(50),
    calorific_value integer
);
 )   DROP TABLE public.vegetables_and_fruits;
       public         heap    postgres    false    841    4         �            1259    20623    vegetables_and_fruits_id_seq    SEQUENCE     �   CREATE SEQUENCE public.vegetables_and_fruits_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 3   DROP SEQUENCE public.vegetables_and_fruits_id_seq;
       public          postgres    false    216    4         �           0    0    vegetables_and_fruits_id_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public.vegetables_and_fruits_id_seq OWNED BY public.vegetables_and_fruits.id;
          public          postgres    false    215                    2604    20627    vegetables_and_fruits id    DEFAULT     �   ALTER TABLE ONLY public.vegetables_and_fruits ALTER COLUMN id SET DEFAULT nextval('public.vegetables_and_fruits_id_seq'::regclass);
 G   ALTER TABLE public.vegetables_and_fruits ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    216    215    216         �          0    20624    vegetables_and_fruits 
   TABLE DATA                 public          postgres    false    216       4784.dat �           0    0    vegetables_and_fruits_id_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public.vegetables_and_fruits_id_seq', 4, true);
          public          postgres    false    215                    2606    20629 0   vegetables_and_fruits vegetables_and_fruits_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public.vegetables_and_fruits
    ADD CONSTRAINT vegetables_and_fruits_pkey PRIMARY KEY (id);
 Z   ALTER TABLE ONLY public.vegetables_and_fruits DROP CONSTRAINT vegetables_and_fruits_pkey;
       public            postgres    false    216                  4784.dat                                                                                            0000600 0004000 0002000 00000000537 14551760635 0014301 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        INSERT INTO public.vegetables_and_fruits VALUES (1, 'Apple', 'Fruit', 'Red', 10);
INSERT INTO public.vegetables_and_fruits VALUES (2, 'Cucumber', 'Vegetable', 'Green', 20);
INSERT INTO public.vegetables_and_fruits VALUES (3, 'Tomato', 'Vegetable', 'Red', 15);
INSERT INTO public.vegetables_and_fruits VALUES (4, 'Pineapple', 'Fruit', 'Yellow', 12);


                                                                                                                                                                 restore.sql                                                                                         0000600 0004000 0002000 00000006574 14551760635 0015414 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1
-- Dumped by pg_dump version 16.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "jan08_HW";
--
-- Name: jan08_HW; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "jan08_HW" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';


ALTER DATABASE "jan08_HW" OWNER TO postgres;

\connect "jan08_HW"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- Name: type_of_food; Type: TYPE; Schema: public; Owner: postgres
--

CREATE TYPE public.type_of_food AS ENUM (
    'Vegetable',
    'Fruit'
);


ALTER TYPE public.type_of_food OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: vegetables_and_fruits; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.vegetables_and_fruits (
    id integer NOT NULL,
    name character varying(55) NOT NULL,
    type public.type_of_food NOT NULL,
    color character varying(50),
    calorific_value integer
);


ALTER TABLE public.vegetables_and_fruits OWNER TO postgres;

--
-- Name: vegetables_and_fruits_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.vegetables_and_fruits_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.vegetables_and_fruits_id_seq OWNER TO postgres;

--
-- Name: vegetables_and_fruits_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.vegetables_and_fruits_id_seq OWNED BY public.vegetables_and_fruits.id;


--
-- Name: vegetables_and_fruits id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vegetables_and_fruits ALTER COLUMN id SET DEFAULT nextval('public.vegetables_and_fruits_id_seq'::regclass);


--
-- Data for Name: vegetables_and_fruits; Type: TABLE DATA; Schema: public; Owner: postgres
--

\i $$PATH$$/4784.dat

--
-- Name: vegetables_and_fruits_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.vegetables_and_fruits_id_seq', 4, true);


--
-- Name: vegetables_and_fruits vegetables_and_fruits_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vegetables_and_fruits
    ADD CONSTRAINT vegetables_and_fruits_pkey PRIMARY KEY (id);


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    